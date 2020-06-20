using System;
using Agiil.Domain;
using Agiil.Domain.Projects;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using CSF.Entities;
using CSF.ORM;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Projects
{
    [TestFixture,Parallelizable]
    public class CurrentlyChosenProjectDecoratorTests
    {
        [Test, AutoMoqData]
        public void GetCurrentProject_returns_project_by_id_if_already_set([HasIdentity] Project project,
                                                                           [Frozen,InMemory] IEntityData data,
                                                                           [Frozen] IAppSessionStore store,
                                                                           CurrentlyChosenProjectDecorator sut)
        {
            data.Add(project);
            var id = project.GetIdentity();
            Mock.Get(store).Setup(x => x.TryGet(SessionKey.CurrentProjectIdentity, out id)).Returns(true);

            Assert.That(() => sut.GetCurrentProject(), Is.SameAs(project));
        }

        [Test, AutoMoqData]
        public void GetCurrentProject_returns_project_from_wrapped_service_if_not_already_chosen([HasIdentity] Project project,
                                                                                                 [Frozen] IAppSessionStore store,
                                                                                                 [Frozen] IGetsCurrentProject wrapped,
                                                                                                 CurrentlyChosenProjectDecorator sut)
        {
            IIdentity<Project> id = null;
            Mock.Get(store).Setup(x => x.TryGet(SessionKey.CurrentProjectIdentity, out id)).Returns(false);
            Mock.Get(wrapped).Setup(x => x.GetCurrentProject()).Returns(project);

            Assert.That(() => sut.GetCurrentProject(), Is.SameAs(project));
        }

        [Test, AutoMoqData]
        public void GetCurrentProject_adds_project_to_session_if_using_wrapped_service([HasIdentity] Project project,
                                                                                       [Frozen] IAppSessionStore store,
                                                                                       [Frozen] IGetsCurrentProject wrapped,
                                                                                       CurrentlyChosenProjectDecorator sut)
        {
            IIdentity<Project> id = null;
            Mock.Get(store).Setup(x => x.TryGet(SessionKey.CurrentProjectIdentity, out id)).Returns(false);
            Mock.Get(wrapped).Setup(x => x.GetCurrentProject()).Returns(project);

            sut.GetCurrentProject();

            Mock.Get(store)
                .Verify(x => x.Set(SessionKey.CurrentProjectIdentity, project.GetIdentity()), Times.Once);
        }
    }
}

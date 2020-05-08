using System;
using System.Collections.Generic;
using Agiil.Domain.Labels;
using Agiil.Tests.Attributes;
using CSF.ORM;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class NewLabelProviderTests
  {
    [Test,AutoMoqData]
    public void GetLabels_creates_a_label_for_each_specified_name(List<string> names,
                                                                  [Frozen] ICreatesLabel labelFactory,
                                                                  NewLabelProvider sut)
    {
      // Arrange
      Mock.Get(labelFactory)
          .Setup(x => x.CreateLabel(It.IsAny<string>()))
          .Returns((string name) => new Label { Name = name });

      // Act
      var result = sut.GetLabels(names);

      // Assert
      Assert.That(result.Count, Is.EqualTo(names.Count));
    }

    [Test,AutoMoqData]
    public void GetLabels_uses_the_factory_to_create_the_labels(List<string> names,
                                                                [Frozen] ICreatesLabel labelFactory,
                                                                NewLabelProvider sut)
    {
      // Arrange
      Mock.Get(labelFactory)
          .Setup(x => x.CreateLabel(It.IsAny<string>()))
          .Returns((string name) => new Label { Name = name });

      // Act
      sut.GetLabels(names);

      // Assert
      Mock.Get(labelFactory)
          .Verify(x => x.CreateLabel(It.IsAny<string>()), Times.Exactly(names.Count));
    }

    [Test,AutoMoqData]
    public void GetLabels_saves_every_created_label(List<string> names,
                                                    [Frozen] ICreatesLabel labelFactory,
                                                    [Frozen] IEntityData data,
                                                    NewLabelProvider sut)
    {
      // Arrange
      Mock.Get(labelFactory)
          .Setup(x => x.CreateLabel(It.IsAny<string>()))
          .Returns((string name) => new Label { Name = name });

      // Act
      sut.GetLabels(names);

      // Assert
      Mock.Get(data)
          .Verify(x => x.Add(It.IsAny<Label>()), Times.Exactly(names.Count));
    }
  }
}

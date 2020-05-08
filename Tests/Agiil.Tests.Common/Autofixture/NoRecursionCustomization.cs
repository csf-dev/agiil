using System;
using System.Linq;
using AutoFixture;

namespace Agiil.Tests.Autofixture
{
    public class NoRecursionCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var throwingBehaviours = fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList();
            foreach(var behaviour in throwingBehaviours)
                fixture.Behaviors.Remove(behaviour);

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}

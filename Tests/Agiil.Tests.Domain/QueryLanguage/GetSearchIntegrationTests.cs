using System;
using Agiil.Bootstrap;
using NUnit.Framework;
using Autofac;
using Agiil.QueryLanguage;
using System.Linq;

namespace Agiil.Tests.QueryLanguage
{
  [TestFixture,Category("Integration")]
  public class GetSearchIntegrationTests
  {
    IAutofacContainerFactory containerProvider = CachingDomainContainerFactory.Default;

    [Test]
    public void GetSearch_can_get_a_search_model_with_an_element_predicate_and_value()
    {
      // Arrange
      var container = containerProvider.GetContainer();
      var searchText = "title like foo";
      GetSearchResult result;

      using(var lifetime = container.BeginLifetimeScope())
      {
        var sut = lifetime.Resolve<IGetsSearch>();

        // Act
        result = sut.GetSearch(searchText);
      }

      // Assert
      var criterion = result?.Search?.Criteria?.Criteria?.FirstOrDefault() as Criterion;
      var predicateAndValue = criterion?.Test as PredicateAndValue;
      var constantValue = predicateAndValue?.Value as ConstantValue;
      Assert.That(criterion?.ElementName, Is.EqualTo("title"), nameof(Criterion.ElementName));
      Assert.That(predicateAndValue?.PredicateText, Is.EqualTo("like"), nameof(PredicateAndValue.PredicateText));
      Assert.That(constantValue?.Text, Is.EqualTo("foo"), $"{nameof(ConstantValue)}.{nameof(ConstantValue.Text)}");
    }
  }
}

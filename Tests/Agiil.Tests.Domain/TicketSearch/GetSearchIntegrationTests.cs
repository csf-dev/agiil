using System;
using Agiil.Bootstrap;
using NUnit.Framework;
using Autofac;
using Agiil.Domain.TicketSearch;
using System.Linq;

namespace Agiil.Tests.TicketSearch
{
  [TestFixture,Category("Integration")]
  public class GetSearchIntegrationTests
  {
    IGetsAutofacContainer containerProvider = CachingDomainContainerFactory.Default;

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
      var criterion = result?.Search?.CriteriaRoot?.Criteria?.FirstOrDefault() as Criterion;
      var predicateAndValue = criterion?.Test as PredicateAndValue;
      var constantValue = predicateAndValue?.Value as ConstantValue;

      Assert.That(criterion?.ElementName, Is.EqualTo("title"), nameof(Criterion.ElementName));
      Assert.That(predicateAndValue?.PredicateText, Is.EqualTo("like"), nameof(PredicateAndValue.PredicateText));
      Assert.That(constantValue?.Text, Is.EqualTo("foo"), $"{nameof(ConstantValue)}.{nameof(ConstantValue.Text)}");
    }

    [Test]
    public void GetSearch_can_get_a_search_model_with_an_element_and_predicate_function()
    {
      // Arrange
      var container = containerProvider.GetContainer();
      var searchText = "LabelText in(\"one two\", three, four)";
      GetSearchResult result;

      using(var lifetime = container.BeginLifetimeScope())
      {
        var sut = lifetime.Resolve<IGetsSearch>();

        // Act
        result = sut.GetSearch(searchText);
      }

      // Assert
      var criterion = result?.Search?.CriteriaRoot?.Criteria?.FirstOrDefault() as Criterion;
      var predicateFunction = criterion?.Test as PredicateFunction;
      var functionParams = predicateFunction.Parameters.OfType<ConstantValue>().ToList();

      Assert.That(criterion?.ElementName, Is.EqualTo("LabelText"), nameof(Criterion.ElementName));
      Assert.That(predicateFunction?.FunctionName, Is.EqualTo("in"), nameof(PredicateFunction.FunctionName));
      Assert.That(functionParams.Select(x => x.Text).ToList(),
                  Is.EqualTo(new [] { "one two", "three", "four" }),
                  nameof(PredicateFunction.Parameters));
    }
  }
}

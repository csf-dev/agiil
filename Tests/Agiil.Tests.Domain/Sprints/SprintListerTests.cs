using System;
using Agiil.Domain.Sprints;
using Agiil.Tests.Attributes;
using CSF.Data;
using CSF.Data.Entities;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Sprints
{
  [TestFixture,Parallelizable]
  public class SprintListerTests
  {
    [Test,AutoMoqData]
    public void GetSprints_returns_only_open_sprints_when_request_specifies([Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                            SprintLister sut,
                                                                            [HasIdentity] Sprint sprintOne,
                                                                            [HasIdentity] Sprint sprintTwo,
                                                                            [HasIdentity] Sprint sprintThree)
    {
      // Arrange
      sprintOne.Closed = false;
      sprintTwo.Closed = true;
      sprintThree.Closed = false;
      query.Add<Sprint>(new [] { sprintOne, sprintTwo, sprintThree });

      var expected = new [] { sprintOne, sprintThree };

      var request = new ListSprintsRequest
      {
        ShowOpenSprints = true,
        ShowClosedSprints = false,
      };

      // Act
      var result = sut.GetSprints(request);

      // Assert
      Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test,AutoMoqData]
    public void GetSprints_returns_only_closed_sprints_when_request_specifies([Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                              SprintLister sut,
                                                                              [HasIdentity] Sprint sprintOne,
                                                                              [HasIdentity] Sprint sprintTwo,
                                                                              [HasIdentity] Sprint sprintThree)
    {
      // Arrange
      sprintOne.Closed = true;
      sprintTwo.Closed = true;
      sprintThree.Closed = false;
      query.Add<Sprint>(new [] { sprintOne, sprintTwo, sprintThree });

      var expected = new [] { sprintOne, sprintTwo };

      var request = new ListSprintsRequest
      {
        ShowOpenSprints = false,
        ShowClosedSprints = true,
      };

      // Act
      var result = sut.GetSprints(request);

      // Assert
      Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test,AutoMoqData]
    public void GetSprints_returns_only_open_sprints_when_request_is_null([Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                          SprintLister sut,
                                                                          [HasIdentity] Sprint sprintOne,
                                                                          [HasIdentity] Sprint sprintTwo,
                                                                          [HasIdentity] Sprint sprintThree)
    {
      // Arrange
      sprintOne.Closed = false;
      sprintTwo.Closed = true;
      sprintThree.Closed = false;
      query.Add<Sprint>(new [] { sprintOne, sprintTwo, sprintThree });

      var expected = new [] { sprintOne, sprintThree };

      // Act
      var result = sut.GetSprints(null);

      // Assert
      Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test,AutoMoqData]
    public void GetSprints_orders_sprints_by_start_dates_when_present([Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                      SprintLister sut,
                                                                      [HasIdentity] Sprint sprintOne,
                                                                      [HasIdentity] Sprint sprintTwo,
                                                                      [HasIdentity] Sprint sprintThree)
    {
      // Arrange
      sprintOne.StartDate = new DateTime(2011, 1, 1);
      sprintTwo.StartDate = new DateTime(2010, 1, 1);
      sprintThree.StartDate = new DateTime(2012, 1, 1);
      query.Add<Sprint>(new [] { sprintOne, sprintTwo, sprintThree });

      var expected = new [] { sprintTwo, sprintOne, sprintThree };

      var request = new ListSprintsRequest
      {
        ShowOpenSprints = true,
        ShowClosedSprints = true,
      };

      // Act
      var result = sut.GetSprints(request);

      // Assert
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test,AutoMoqData]
    public void GetSprints_orders_sprints_by_creation_timestamps_when_start_dates_are_missing([Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                                              SprintLister sut,
                                                                                              [HasIdentity] Sprint sprintOne,
                                                                                              [HasIdentity] Sprint sprintTwo,
                                                                                              [HasIdentity] Sprint sprintThree)
    {
      // Arrange
      sprintOne.StartDate = null;
      sprintOne.CreationDate = new DateTime(2010, 6, 1);
      sprintTwo.StartDate = new DateTime(2010, 1, 1);
      sprintThree.StartDate = new DateTime(2012, 1, 1);
      query.Add<Sprint>(new [] { sprintOne, sprintTwo, sprintThree });

      var expected = new [] { sprintTwo, sprintOne, sprintThree };

      var request = new ListSprintsRequest
      {
        ShowOpenSprints = true,
        ShowClosedSprints = true,
      };

      // Act
      var result = sut.GetSprints(request);

      // Assert
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}

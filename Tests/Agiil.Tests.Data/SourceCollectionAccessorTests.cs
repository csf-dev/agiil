using Agiil.Data.ConventionMappings;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Agiil.Tests.Data
{
  [TestFixture,Parallelizable]
  public class SourceCollectionAccessorTests
  {
    [Test, AutoMoqData]
    public void GetGetter_returns_non_null_for_Sprint_Tickets(SourceCollectionAccessor sut)
    {
      var getter = sut.GetGetter(typeof(Sprint), nameof(Sprint.Tickets));

      Assert.That(getter, Is.Not.Null);
    }

    [Test, AutoMoqData]
    public void GetSetter_returns_non_null_for_Sprint_Tickets(SourceCollectionAccessor sut)
    {
      var setter = sut.GetSetter(typeof(Sprint), nameof(Sprint.Tickets));

      Assert.That(setter, Is.Not.Null);
    }

    [Test, AutoMoqData]
    public void GetGetter_returns_a_viable_object_for_Sprint_Tickets(Sprint sprint,
                                                                     Ticket ticket,
                                                                     SourceCollectionAccessor sut)
    {
      sprint.Tickets.Clear();
      sprint.Tickets.Add(ticket);
      var getter = sut.GetGetter(typeof(Sprint), nameof(Sprint.Tickets));

      var result = getter.Get(sprint);

      Assert.That(result, Is.EquivalentTo(new[] { ticket }));
    }

    [Test, AutoMoqData]
    public void GetSetter_returns_a_viable_object_for_Sprint_Tickets(Sprint sprint,
                                                                     Ticket ticket,
                                                                     SourceCollectionAccessor sut)
    {
      sprint.Tickets.Clear();
      var setter = sut.GetSetter(typeof(Sprint), nameof(Sprint.Tickets));

      setter.Set(sprint, new HashSet<Ticket>(new[] { ticket }));

      Assert.That(sprint.Tickets, Is.EquivalentTo(new[] { ticket }));
    }
  }
}

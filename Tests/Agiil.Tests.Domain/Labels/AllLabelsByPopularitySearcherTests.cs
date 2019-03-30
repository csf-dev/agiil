using System;
using System.Linq;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using CSF.Collections;
using CSF.Data.Entities;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Labels
{
  [TestFixture,Parallelizable]
  public class AllLabelsByPopularitySearcherTests
  {
    [Test,AutoMoqData]
    public void GetLabels_returns_a_label_with_2_open_tickets_before_one_with_1_open_tickets([Frozen,InMemory] IEntityData entityData,
                                                                                             AllLabelsByPopularitySearcher sut,
                                                                                             Label label1,
                                                                                             Label label2,
                                                                                             Ticket ticket1,
                                                                                             Ticket ticket2,
                                                                                             Ticket ticket3)
    {
      // Arrange
      ticket1.Closed = false;
      ticket2.Closed = false;
      ticket3.Closed = false;

      label1.Name = "Label 1";
      label2.Name = "Label 2";
      label1.Tickets.ReplaceContents(new[] { ticket1 });
      label2.Tickets.ReplaceContents(new[] { ticket2, ticket3 });

      entityData.Add(label1);
      entityData.Add(label2);

      // Act
      var result = sut.GetLabels(null, null);

      // Assert
      var labelNames = result.Select(x => x.Name).ToArray();
      Assert.That(labelNames, Is.EqualTo(new [] { "Label 2", "Label 1" }));
    }

    [Test,AutoMoqData]
    public void GetLabels_does_not_return_more_labels_than_the_maximum_when_it_is_specified([Frozen,InMemory] IEntityData entityData,
                                                                                            AllLabelsByPopularitySearcher sut,
                                                                                            Label label1,
                                                                                            Label label2,
                                                                                            Label label3,
                                                                                            Label label4)
    {
      // Arrange
      entityData.Add(label1);
      entityData.Add(label2);
      entityData.Add(label3);
      entityData.Add(label4);

      // Act
      var result = sut.GetLabels(null, 3);

      // Assert
      Assert.That(result.Count, Is.EqualTo(3));
    }
  }
}

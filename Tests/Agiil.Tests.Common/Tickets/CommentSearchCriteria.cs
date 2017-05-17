using System;
namespace Agiil.Tests.Tickets
{
  public class CommentSearchCriteria
  {
    public long? TicketId { get; set; }

    public string Author { get; set; }

    public string Body { get; set; }
  }
}

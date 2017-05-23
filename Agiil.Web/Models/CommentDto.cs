using System;
namespace Agiil.Web.Models
{
  public class CommentDto
  {
    public long Id { get; set; }
    public string Author { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime LastEditTimestamp { get; set; }
    public string AuthoredTimestamp => Timestamp.ToString("u");
    public string EditedTimestamp => LastEditTimestamp.ToString("u");
    public string Body { get; set; }
  }
}

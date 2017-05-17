using System;
namespace Agiil.Web.Models
{
  public class CommentDto
  {
    public string Author { get; set; }
    public DateTime Timestamp { get; set; }
    public string AuthoredTimestamp => Timestamp.ToString("u");
    public string Body { get; set; }
  }
}

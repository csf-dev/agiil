using System;
namespace Agiil.Web.Models
{
  public class CommentDto
  {
    public string Author { get; set; }
    public DateTime CreationTimestamp { get; set; }
    public string AuthoredTimestamp => CreationTimestamp.ToString("u");
    public string Body { get; set; }
  }
}

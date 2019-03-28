using System;
namespace Agiil.Domain.Activity
{
  public class AddWorklogResponse
  {
    public bool Success { get; set; }

    public bool InvalidTime { get; set; }
    
    public bool InvalidTicket { get; set; }
  }
}

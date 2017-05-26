using System;
namespace Agiil.Domain.Validation
{
  public static class RuleNames
  {
    public static class Comments
    {
      public static readonly string EditingPermissionDenied = "EditingPermissionDenied";
    }

    public static readonly string EntityMustExist = "EntityMustExist";

    public static readonly string EndDateBeforeStartDate = "EndDateBeforeStartDate";
  }
}

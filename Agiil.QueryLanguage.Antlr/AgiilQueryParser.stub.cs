using System;
namespace Agiil.QueryLanguage
{
  public partial class AgiilQueryParser : IGetsSearchContext
  {
    SearchContext IGetsSearchContext.GetSearchContext() => search();
  }
}

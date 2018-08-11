using System;
namespace Agiil.QueryLanguage
{
  public interface IGetsSearchContext
  {
    AgiilQueryParser.SearchContext GetSearchContext();
  }
}

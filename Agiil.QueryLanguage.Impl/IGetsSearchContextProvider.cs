using System;

namespace Agiil.QueryLanguage
{
  public interface IGetsSearchContextProvider
  {
    IGetsSearchContext GetSearchContextProvider(string text);
  }
}

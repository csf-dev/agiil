﻿using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public class Function : Value
  {
    IList<Value> parameters;

    public string FunctionName { get; set; }

    public IList<Value> Parameters
    {
      get { return parameters; }
      set { parameters = value ?? new List<Value>(); }
    }

    public Function()
    {
      parameters = new List<Value>();
    }
  }
}

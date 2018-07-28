using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Agiil.Domain.TicketSearch;

namespace Agiil.QueryLanguage.Visitors
{
  public class FunctionVisitor : AgiilQueryBaseVisitor<Function>
  {
		private readonly IAgiilQueryVisitor<Value> parameterVisitor;

    public override Function VisitFunctioninvocation([NotNull] AgiilQueryParser.FunctioninvocationContext functionContext)
		{
      return new Function {
        FunctionName = GetFunctionName(functionContext),
        Parameters = GetParameters(functionContext),
      };
		}

		public override Function VisitElementtest([NotNull] AgiilQueryParser.ElementtestContext context)
    {
      var functionContext = context.functioninvocation();
      if(functionContext == null) return null;

      return new PredicateFunction {
        FunctionName = GetFunctionName(functionContext),
        Parameters = GetParameters(functionContext),
        Inverted = context.NOT() != null,
      };
		}

    protected override bool ShouldVisitNextChild(IRuleNode node, Function currentResult) => false;

		string GetFunctionName(AgiilQueryParser.FunctioninvocationContext context)
      => context.NAME().GetText();

    IList<Value> GetParameters(AgiilQueryParser.FunctioninvocationContext context)
    {
      var parameterContext = context.functionparameters();
      return parameterContext.value()
                             .Select(x => parameterVisitor.Visit(x))
                             .ToList();
    }

    public FunctionVisitor(IAgiilQueryVisitor<Value> parameterVisitor)
    {
      if(parameterVisitor == null)
        throw new ArgumentNullException(nameof(parameterVisitor));
      this.parameterVisitor = parameterVisitor;
    }
	}
}

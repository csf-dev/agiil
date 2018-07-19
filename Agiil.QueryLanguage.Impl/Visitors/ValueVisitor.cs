using System;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class ValueVisitor : AgiilQueryBaseVisitor<Value>
  {
    readonly Lazy<IAgiilQueryVisitor<Function>> functionVisitor;

		public override Value VisitValue([NotNull] AgiilQueryParser.ValueContext context)
		{
      return GetFunction(context) ?? GetConstantValue(context);
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, Value currentResult) => false;

		Value GetFunction(AgiilQueryParser.ValueContext context)
    {
      var func = context.functioninvocation();
      if(func == null) return null;

      return functionVisitor.Value.Visit(func);
    }

    Value GetConstantValue(AgiilQueryParser.ValueContext context)
    {
      var quotedValue = context.constantvalue()?.QUOTEDVALUE()?.GetText();
      if(quotedValue != null && quotedValue.Length >= 2)
        return new ConstantValue { Text = quotedValue.Trim('"') };

      return new ConstantValue { Text = context.constantvalue()?.GetText() };
    }

    public ValueVisitor(Lazy<IAgiilQueryVisitor<Function>> functionVisitor)
    {
      if(functionVisitor == null)
        throw new ArgumentNullException(nameof(functionVisitor));
      this.functionVisitor = functionVisitor;
    }
	}
}

using System;
using System.IO;
using System.Linq;
using CSF.Validation;
using CSF.Validation.Rules;
using CSF.Validation.ValidationRuns;
using log4net.ObjectRenderer;

namespace Agiil.Domain.Validation
{
  public class ValidationResultRenderer : IObjectRenderer
  {
    public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
    {
      if(ReferenceEquals(rendererMap, null) || ReferenceEquals(writer, null)) return;
      var result = obj as IValidationResult;
      if(ReferenceEquals(result, null))
      {
        writer.Write("<null>");
        return;
      }

      writer.Write($"[{nameof(IValidationResult)}: {nameof(IValidationResult.IsSuccess)} = {result.IsSuccess}\n{GetRuleResults(result)}\n]");
    }

    string GetRuleResults(IValidationResult result)
    {
      var individualResults = result.RuleResults.Select(GetRuleResult);
      return String.Join("\n", individualResults);
    }

    string GetRuleResult(IRunnableRuleResult ruleResult)
    {
      var result = $"    {ruleResult.ManifestIdentity}: {ruleResult.RuleResult.Outcome}";

      var exceptionResult = ruleResult.RuleResult as ExceptionResult;
      if(exceptionResult != null)
        result = String.Concat(result, "\n", exceptionResult.Exception);

      return result;
    }
  }
}

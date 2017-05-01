using System;
using System.Linq;
using CSF.Reflection;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Rules;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketResponse
  {
    static readonly RuleOutcome[] SuccessOutcomes = new RuleOutcome[] {
      RuleOutcome.Success,
      RuleOutcome.IntentionallySkipped,
    };

    readonly IValidationResult validationResult;

    public Ticket Ticket { get; private set; }

    public bool TitleIsInvalid
    {
      get {
        if(validationResult.IsSuccess)
          return false;

        return validationResult
          .RuleResults
          .Where(x => !SuccessOutcomes.Contains(x.RuleResult.Outcome))
          .Select(x => x.ManifestIdentity)
          .Cast<DefaultManifestIdentity>()
          .Any(x => x.ValidatedMember == Reflect.Property<CreateTicketRequest>(r => r.Title));
      }
    }

    public bool DescriptionIsInvalid
    {
      get {
        if(validationResult.IsSuccess)
          return false;

        return validationResult
          .RuleResults
          .Where(x => !SuccessOutcomes.Contains(x.RuleResult.Outcome))
          .Select(x => x.ManifestIdentity)
          .Cast<DefaultManifestIdentity>()
          .Any(x => x.ValidatedMember == Reflect.Property<CreateTicketRequest>(r => r.Description));
      }
    }

    public CreateTicketResponse(IValidationResult result, Ticket createdTicket = null)
    {
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      Ticket = createdTicket;
      this.validationResult = result;
    }
  }
}

using System;
using Agiil.Domain.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
  public class TicketReferenceStringResolver : IValueResolver<IIdentifiesTicketByProjectAndNumber, object, string>
  {
    readonly IParsesTicketReference referenceParser;

    public string Resolve(IIdentifiesTicketByProjectAndNumber source,
                          object destination,
                          string destMember,
                          ResolutionContext context)
    {
      return referenceParser.GetReference(source).ToString(false);
    }

    public TicketReferenceStringResolver(IParsesTicketReference referenceParser)
    {
      if(referenceParser == null)
        throw new ArgumentNullException(nameof(referenceParser));
      this.referenceParser = referenceParser;
    }
  }
}

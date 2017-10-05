using System;
using Agiil.Domain.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
  public class TicketReferenceStringResolver : IValueResolver<IIdentifiesTicketByProjectAndNumber, object, string>
  {
    readonly ITicketReferenceParser referenceParser;

    public string Resolve(IIdentifiesTicketByProjectAndNumber source,
                          object destination,
                          string destMember,
                          ResolutionContext context)
    {
      return referenceParser.CreateReference(source);
    }

    public TicketReferenceStringResolver(ITicketReferenceParser referenceParser)
    {
      if(referenceParser == null)
        throw new ArgumentNullException(nameof(referenceParser));
      this.referenceParser = referenceParser;
    }
  }
}

using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class AddRelationshipModelToAddRelationshipRequestProfile : Profile
  {
    public AddRelationshipModelToAddRelationshipRequestProfile()
    {
      CreateMap<AddRelationshipModel,AddRelationshipRequest>()
        .ForMember(x => x.RelationshipId, opts => opts.ResolveUsing(GetRelationshipIdentity))
        .ForMember(x => x.ParticipationType, opts => opts.ResolveUsing(GetRelationshipParticipant))
        ;
    }

    IIdentity<Relationship> GetRelationshipIdentity(AddRelationshipModel model)
    {
      var values = GetIdAndParticipation(model?.RelationshipIdAndParticipation);
      if(values == null) return null;

      return Identity.Parse<Relationship>(values.Item1);
    }

    RelationshipParticipant GetRelationshipParticipant(AddRelationshipModel model)
    {
      var values = GetIdAndParticipation(model?.RelationshipIdAndParticipation);
      if(values == null) return default(RelationshipParticipant);

      return (RelationshipParticipant) Enum.Parse(typeof(RelationshipParticipant), values.Item2, true);
    }

    Tuple<string,string> GetIdAndParticipation(string combinedValue)
    {
      if(combinedValue == null) return null;
      var parts = combinedValue.Split('-');
      if(parts.Length != 2) return null;
      return Tuple.Create(parts[0], parts[1]);
    }
  }
}

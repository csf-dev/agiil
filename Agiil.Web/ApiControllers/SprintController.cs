using System;
using System.Web.Http;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.ApiControllers
{
  public class SprintController : ApiControllerBase
  {
    readonly Lazy<ISprintCreator> creator;

    public NewSprintResult Put(NewSprintSpecification spec)
    {
      var request = Mapper.Map<CreateSprintRequest>(spec);
      var response = creator.Value.Create(request);
      return Mapper.Map<NewSprintResult>(response);
    }

    public SprintController(ApiControllerBaseDependencies deps,
                            Lazy<ISprintCreator> creator) : base(deps)
    {
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      this.creator = creator;
    }
  }
}

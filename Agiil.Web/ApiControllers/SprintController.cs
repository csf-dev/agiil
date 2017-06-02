using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class SprintController : ApiControllerBase
  {
    readonly Lazy<ISprintCreator> creator;
    readonly Lazy<ISprintDetailService> detailService;
    readonly Lazy<ISprintEditor> editor;

    public NewSprintResult Put(NewSprintSpecification spec)
    {
      var request = Mapper.Map<CreateSprintRequest>(spec);
      var response = creator.Value.Create(request);
      return Mapper.Map<NewSprintResult>(response);
    }

    public Models.Sprints.EditSprintResponse Post(EditSprintSpecification sprint)
    {
      if(sprint == null)
        throw new ArgumentNullException(nameof(sprint));

      var request = Mapper.Map<EditSprintRequest>(sprint);
      var response = editor.Value.Edit(request);

      if(response.IdIsInvalid)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<Models.Sprints.EditSprintResponse>(response);
    }

    public SprintDetailDto Get(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<SprintDetailDto>(sprint);
    }

    public SprintController(ApiControllerBaseDependencies deps,
                            Lazy<ISprintCreator> creator,
                            Lazy<ISprintDetailService> detailService,
                            Lazy<ISprintEditor> editor) : base(deps)
    {
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(detailService == null)
        throw new ArgumentNullException(nameof(detailService));
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      this.creator = creator;
      this.editor = editor;
      this.detailService = detailService;
    }
  }
}

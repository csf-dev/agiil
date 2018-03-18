using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class SprintController : ApiController
  {
    readonly Lazy<ISprintCreator> creator;
    readonly Lazy<ISprintDetailService> detailService;
    readonly Lazy<ISprintEditor> editor;
    readonly Lazy<IMapper> mapper;

    public NewSprintResult Put(NewSprintSpecification spec)
    {
      var request = mapper.Value.Map<CreateSprintRequest>(spec);
      var response = creator.Value.Create(request);
      return mapper.Value.Map<NewSprintResult>(response);
    }

    public Models.Sprints.EditSprintResponse Post(EditSprintSpecification sprint)
    {
      if(sprint == null)
        throw new ArgumentNullException(nameof(sprint));

      var request = mapper.Value.Map<EditSprintRequest>(sprint);
      var response = editor.Value.Edit(request);

      if(response.IdIsInvalid)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return mapper.Value.Map<Models.Sprints.EditSprintResponse>(response);
    }

    public SprintDetailDto Get(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return mapper.Value.Map<SprintDetailDto>(sprint);
    }

    public SprintController(Lazy<IMapper> mapper,
                            Lazy<ISprintCreator> creator,
                            Lazy<ISprintDetailService> detailService,
                            Lazy<ISprintEditor> editor)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(detailService == null)
        throw new ArgumentNullException(nameof(detailService));
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      this.mapper = mapper;
      this.creator = creator;
      this.editor = editor;
      this.detailService = detailService;
    }
  }
}

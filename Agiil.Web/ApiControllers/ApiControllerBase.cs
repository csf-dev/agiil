using System;
using System.Web.Http;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
  public class ApiControllerBase : ApiController
  {
    readonly Lazy<IMapper> mapper;

    protected virtual IMapper Mapper => mapper.Value;

    public ApiControllerBase(ApiControllerBaseDependencies deps)
    {
      if(deps == null)
        throw new ArgumentNullException(nameof(deps));

      mapper = deps.Mapper;
    }
  }
}

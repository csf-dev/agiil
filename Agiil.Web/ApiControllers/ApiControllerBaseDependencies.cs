using System;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
  // HACK: I don't really like this "dependencies object" anti-pattern.
  // However, it's difficult to break these apart as things stand because the controllers are the entry points.
  // Consider other ways in which this could be done.
  public class ApiControllerBaseDependencies
  {
    readonly Lazy<IMapper> mapper;

    public Lazy<IMapper> Mapper => mapper;

    public ApiControllerBaseDependencies(Lazy<IMapper> mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      this.mapper = mapper;
    }
  }
}

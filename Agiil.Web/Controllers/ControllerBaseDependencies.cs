using System;
using Agiil.Web.Services.SharedModel;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  // HACK: I don't really like this "dependencies object" anti-pattern.
  // However, it's difficult to break these apart as things stand because the controllers are the entry points.
  // Consider other ways in which this could be done.
  public class ControllerBaseDependencies
  {
    readonly StandardPageModelFactory standardModelFactory;
    readonly Lazy<IMapper> mapper;

    public StandardPageModelFactory StandardModelFactory => standardModelFactory;
    public Lazy<IMapper> Mapper => mapper;

    public ControllerBaseDependencies(StandardPageModelFactory standardModelFactory,
                                      Lazy<IMapper> mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(standardModelFactory == null)
        throw new ArgumentNullException(nameof(standardModelFactory));
      
      this.mapper = mapper;
      this.standardModelFactory = standardModelFactory;
    }
  }
}

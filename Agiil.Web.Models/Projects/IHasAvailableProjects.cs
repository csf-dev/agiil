using System;
namespace Agiil.Web.Models.Projects
{
    public interface IHasAvailableProjects
    {
        AvailableProjectsModel AvailableProjects { get; set; }
    }
}

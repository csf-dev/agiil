using System;
namespace Agiil.Domain.Projects
{
    public interface IGetsProject
    {
        Project GetProject(string code);
    }
}

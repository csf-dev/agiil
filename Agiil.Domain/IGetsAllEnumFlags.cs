using System;
namespace Agiil.Domain
{
    public interface IGetsAllEnumFlags
    {
        T GetValueWithAllFlags<T>() where T : struct;
    }
}

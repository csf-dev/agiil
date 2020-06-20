using System;
using CSF.Entities;

namespace Agiil.Domain.App
{
    public class AgiilApp : Entity<long>
    {
        internal const long DefaultId = 1;

        private AgiilApp()
        {
            IdentityValue = DefaultId;
        }

        public static AgiilApp Instance { get; } = new AgiilApp();
    }
}

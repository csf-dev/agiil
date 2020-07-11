using System;
using System.Linq;
using System.Web;
using Agiil.Domain;

namespace Agiil.Web.Services
{
    public class MvcSessionStore : IAppSessionStore
    {
        readonly HttpSessionStateBase session;

        public void Set<T>(string key, T value) => session.Add(key, value);

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);
            if(!session.Keys.Cast<string>().Contains(key))
                return false;

            try
            {
                var val = session[key];
                value = (T) val;
                return true;
            }
            catch(InvalidCastException)
            {
                return false;
            }
        }

        public MvcSessionStore(HttpSessionStateBase session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }
    }
}

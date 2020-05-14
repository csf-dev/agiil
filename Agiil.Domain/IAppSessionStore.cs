using System;
namespace Agiil.Domain
{
    /// <summary>
    /// An object which provides an abstraction to read &amp; write
    /// transient data relating to the current user's session of using
    /// the application.
    /// </summary>
    public interface IAppSessionStore
    {
        /// <summary>
        /// Attempts to get a value from the current session storage, of a specified key and generic type.
        /// </summary>
        /// <returns><c>true</c>, if a value was found with the specified key, <c>false</c> if no value was found, or the value could not be converted to the expected type.</returns>
        /// <param name="key">The key for the value.</param>
        /// <param name="value">The output value from the store, or an undefined value/object if the method returned <c>false</c>.</param>
        /// <typeparam name="T">The expected type of the value.</typeparam>
        bool TryGet<T>(string key, out T value);

        /// <summary>
        /// Sets (either adds or updates) a value into the session storage, using a specified key.
        /// </summary>
        /// <param name="key">The key under which to store the value.</param>
        /// <param name="value">The value to store.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        void Set<T>(string key, T value);
    }
}

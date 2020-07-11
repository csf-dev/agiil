using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// An exception raised when a user attempts to perform an action, but they do not have the required capabilities
    /// to do so.
    /// </summary>
    [Serializable]
    public class UserMustHaveCapabilityException : Exception
    {
        public IIdentity<User> UserIdentity { get; }

        public IIdentity EntityIdentity { get; }

        public string RequiredCapabilities { get; }

        public string ActualCapabilities { get; }

        public string ActionName { get; }

        public UserMustHaveCapabilityException(string message,
                                               IIdentity<User> userIdentity,
                                               IIdentity entityIdentity,
                                               string requiredCapabilities,
                                               string actualCapabilities,
                                               string actionName = null) : base(message)
        {
            UserIdentity = userIdentity;
            EntityIdentity = entityIdentity;
            RequiredCapabilities = requiredCapabilities;
            ActualCapabilities = actualCapabilities;
            ActionName = actionName;
        }

        public UserMustHaveCapabilityException(string message,
                                               Exception inner,
                                               IIdentity<User> userIdentity,
                                               IIdentity entityIdentity,
                                               string requiredCapabilities,
                                               string actualCapabilities,
                                               string actionName = null) : base(message, inner)
        {
            UserIdentity = userIdentity;
            EntityIdentity = entityIdentity;
            RequiredCapabilities = requiredCapabilities;
            ActualCapabilities = actualCapabilities;
            ActionName = actionName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMustHaveCapabilityException"/> class
        /// </summary>
        public UserMustHaveCapabilityException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMustHaveCapabilityException"/> class
        /// </summary>
        /// <param name="message">A <see cref="String"/> that describes the exception. </param>
        public UserMustHaveCapabilityException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMustHaveCapabilityException"/> class
        /// </summary>
        /// <param name="message">A <see cref="String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public UserMustHaveCapabilityException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMustHaveCapabilityException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected UserMustHaveCapabilityException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// Raised when an appropriate implementation of <see cref="IGetsTargetEntityIdentity{TEntity, TObject}"/>
    /// could not be found or resolved.
    /// </summary>
    [Serializable]
    public class IdentityProviderNotAvailableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderNotAvailableException"/> class
        /// </summary>
        public IdentityProviderNotAvailableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderNotAvailableException"/> class
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
        public IdentityProviderNotAvailableException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderNotAvailableException"/> class
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public IdentityProviderNotAvailableException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderNotAvailableException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected IdentityProviderNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

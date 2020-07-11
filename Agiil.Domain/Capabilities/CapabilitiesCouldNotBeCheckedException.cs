using System;
namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// Raised when an error occurs whilst asserting that the user has capabilities.
    /// </summary>
    [System.Serializable]
    public class CapabilitiesCouldNotBeCheckedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilitiesCouldNotBeCheckedException"/> class
        /// </summary>
        public CapabilitiesCouldNotBeCheckedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilitiesCouldNotBeCheckedException"/> class
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
        public CapabilitiesCouldNotBeCheckedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilitiesCouldNotBeCheckedException"/> class
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public CapabilitiesCouldNotBeCheckedException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapabilitiesCouldNotBeCheckedException"/> class
        /// </summary>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="info">The object that holds the serialized object data.</param>
        protected CapabilitiesCouldNotBeCheckedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}

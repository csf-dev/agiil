using System;
using System.Runtime.Serialization;

namespace Agiil.Domain.Validation
{
  [Serializable]
  public class MissingValidatorFactoryException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:MissingValidatorFactoryException"/> class
    /// </summary>
    public MissingValidatorFactoryException ()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:MissingValidatorFactoryException"/> class
    /// </summary>
    /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
    public MissingValidatorFactoryException (string message) : base (message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:MissingValidatorFactoryException"/> class
    /// </summary>
    /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
    /// <param name="inner">The exception that is the cause of the current exception. </param>
    public MissingValidatorFactoryException (string message, Exception inner) : base (message, inner)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:MissingValidatorFactoryException"/> class
    /// </summary>
    /// <param name="context">The contextual information about the source or destination.</param>
    /// <param name="info">The object that holds the serialized object data.</param>
    protected MissingValidatorFactoryException (SerializationInfo info, StreamingContext context) : base (info, context)
    {
    }
  }
}

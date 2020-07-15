using System;
using CSF.Configuration;

namespace Agiil.Bootstrap.DiConfiguration
{
    public class ContainerFactoryProvider
    {
        // Because this type is used to create a DI container, we can't use DI for its dependencies!
        readonly IConfigurationReader configReader = new ConfigurationReader();

        public IGetsAutofacContainer GetContainerBuilderFactory()
        {
            var factoryType = GetFactoryType();

            return (IGetsAutofacContainer) Activator.CreateInstance(factoryType);
        }

        Type GetFactoryType()
        {
            var config = configReader.ReadSection<DiConfigurationSection>();

            if(String.IsNullOrEmpty(config?.FactoryTypeName))
                return typeof(DomainContainerFactory);

            var type = Type.GetType(config.FactoryTypeName);
            if(type == null)
                throw new CannotGetDiContainerFactoryException($"Configuration specifies container factory type `{config.FactoryTypeName}' but this type cannot be found.");

            return type;
        }

        /// <summary>
        /// Exception raised when a DI container factory cannot be created.
        /// </summary>
        [Serializable]
        public class CannotGetDiContainerFactoryException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CannotGetDiContainerFactoryException"/> class
            /// </summary>
            public CannotGetDiContainerFactoryException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CannotGetDiContainerFactoryException"/> class
            /// </summary>
            /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
            public CannotGetDiContainerFactoryException(string message) : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CannotGetDiContainerFactoryException"/> class
            /// </summary>
            /// <param name="message">A <see cref="System.String"/> that describes the exception. </param>
            /// <param name="inner">The exception that is the cause of the current exception. </param>
            public CannotGetDiContainerFactoryException(string message, Exception inner) : base(message, inner)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CannotGetDiContainerFactoryException"/> class
            /// </summary>
            /// <param name="context">The contextual information about the source or destination.</param>
            /// <param name="info">The object that holds the serialized object data.</param>
            protected CannotGetDiContainerFactoryException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
            }
        }
    }
}

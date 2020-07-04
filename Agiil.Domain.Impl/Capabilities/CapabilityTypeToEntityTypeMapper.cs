using System;
using System.Collections.Generic;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityTypeToEntityTypeMapper : IGetsEntityTypeForCapability
    {
        static readonly IReadOnlyDictionary<Type, Type> CapabilityTypeToEntityTypeMapping = new Dictionary<Type, Type> {
            { typeof(Projects.ProjectCapability),   typeof(Projects.Project) },
            { typeof(App.AppCapability),            typeof(App.AgiilApp) },
            { typeof(Tickets.TicketCapability),     typeof(Tickets.Ticket) },
            { typeof(Tickets.CommentCapability),    typeof(Tickets.Comment) },
        };

        public Type GetEntityType(object capability)
        {
            /* To extend the logic of this function, add new items to CapabilityTypeToEntityTypeMapping,
             * matching new capability types to new entity types.           
             */
            var capabilityType = capability?.GetType();
            if(capabilityType == null) return null;

            if(!CapabilityTypeToEntityTypeMapping.ContainsKey(capabilityType))
                return null;

            return CapabilityTypeToEntityTypeMapping[capabilityType];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;
using log4net;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
    public class CircularRelationshipDetector : IDetectsCircularRelationship
    {
        readonly ILog logger;

        public bool IsRelationshipCircular(IIdentity<Relationship> relationshipType,
                                           IEnumerable<TraversibleRelationship> allRelationships)
        {
            if(allRelationships == null || !allRelationships.Any())
                return false;
            if(relationshipType == null)
                throw new ArgumentNullException(nameof(relationshipType));

            if(logger.IsDebugEnabled)
                logger.Debug("All relationships:" + String.Join(", ", allRelationships));

            var candidates = allRelationships.Where(x => Equals(x.Type, relationshipType)).ToList();
            return IsCircularRelationshipDetected(candidates);
        }

        bool IsCircularRelationshipDetected(IReadOnlyCollection<TraversibleRelationship> relationships)
        {
            foreach(var relationship in relationships)
            {
                if(CanRelationshipTraverseBackToItself(relationship, relationships))
                    return true;
            }

            return false;
        }

        bool CanRelationshipTraverseBackToItself(TraversibleRelationship initial, IReadOnlyCollection<TraversibleRelationship> candidates)
        {
            ISet<TraversibleRelationship>
                openList = new HashSet<TraversibleRelationship> { initial };

            for(var current = openList.FirstOrDefault();
                current != null;
                current = openList.FirstOrDefault())
            {
                openList.Remove(current);

                var traversible = candidates.Where(current.CanTraverseTo).ToList();
                if(traversible.Any(x => Equals(x, initial)))
                {
                    if(logger.IsDebugEnabled)
                        logger.Debug($"Found circular relationship: {initial} was able to traverse a path back to itself");
                    return true;
                }

                openList.UnionWith(traversible);
            }

            return false;
        }

        public CircularRelationshipDetector(ILog logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}

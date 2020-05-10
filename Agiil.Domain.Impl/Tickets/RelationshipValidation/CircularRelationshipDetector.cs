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

        bool IsCircularRelationshipDetected(IReadOnlyCollection<TraversibleRelationship> candidates)
        {
            var remainingCandidates = candidates;
            var traversed = new HashSet<TraversibleRelationship>();

            do
            {
                var initial = remainingCandidates.First();
                ICollection<TraversibleRelationship> traversedInThisAttempt;
                var isCircularRelationshipDetected = IsCircularRelationshipDetected(initial, candidates, out traversedInThisAttempt);
                if(isCircularRelationshipDetected)
                    return true;

                traversed.UnionWith(traversedInThisAttempt);
                remainingCandidates = remainingCandidates.Except(traversed).ToList();

            } while(traversed.Count < candidates.Count);

            return false;
        }

        /// <summary>
        /// Effectively a Breadth-First-Search through the traversible relationships.  Returns true if we encounter
        /// an item on the closed list, whilst traversing through the open list.
        /// </summary>
        /// <returns><c>true</c>, if a circular relationship was detected, <c>false</c> otherwise.</returns>
        /// <param name="initial">Initial relationship from which to begin the search.</param>
        /// <param name="candidates">Candidate relationships.</param>
        /// <param name="traversed">Relationships which have been traversed.</param>
        bool IsCircularRelationshipDetected(TraversibleRelationship initial,
                                            IReadOnlyCollection<TraversibleRelationship> candidates,
                                            out ICollection<TraversibleRelationship> traversed)
        {
            traversed = new List<TraversibleRelationship>();
            ISet<TraversibleRelationship>
                openList = new HashSet<TraversibleRelationship> { initial },
                closedList = new HashSet<TraversibleRelationship>();

            while(openList.Any())
            {
                var current = openList.First();
                openList.Remove(current);
                traversed.Add(current);

                var traversible = candidates.Where(current.CanTraverseTo).ToList();
                var circular = traversible.FirstOrDefault(x => closedList.Contains(x));
                if(circular != null)
                {
                    if(logger.IsDebugEnabled)
                        logger.Debug($"Found circular relationship: {circular}");
                    return true;
                }

                openList.UnionWith(traversible);
                closedList.Add(current);
            }

            return false;
        }

        public CircularRelationshipDetector(ILog logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}

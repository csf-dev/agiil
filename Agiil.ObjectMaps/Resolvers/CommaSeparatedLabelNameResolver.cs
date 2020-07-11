using System;
using System.Collections.Generic;
using Agiil.Domain.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
    public class CommaSeparatedLabelNameResolver : IMemberValueResolver<object,object,IEnumerable<Label>,string>
    {
        readonly IParsesLabelNames labelNameParser;

        public string Resolve(object source,
                              object destination,
                              IEnumerable<Label> sourceMember,
                              string destMember,
                              ResolutionContext context)
            => labelNameParser.GetCommaSeparatedLabelNames(sourceMember);

        public CommaSeparatedLabelNameResolver(IParsesLabelNames labelNameParser)
        {
            this.labelNameParser = labelNameParser ?? throw new ArgumentNullException(nameof(labelNameParser));
        }
    }
}

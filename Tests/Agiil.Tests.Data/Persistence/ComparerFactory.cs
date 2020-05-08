using System;
using System.Collections.Generic;
using CSF.EqualityRules;

namespace Agiil.Tests.Data.Persistence
{
    public class ComparerFactory
    {
        public static IEqualityComparer<DateTime> GetDateTimeAccurateToSecondsComparer()
        {
            return new EqualityBuilder<DateTime>()
                .ForProperty(x => x.Year)
                .ForProperty(x => x.Month)
                .ForProperty(x => x.Day)
                .ForProperty(x => x.Hour)
                .ForProperty(x => x.Minute)
                .ForProperty(x => x.Second)
                .Build();
        }

        public static IEqualityComparer<DateTime?> GetNullableDateTimeAccurateToSecondsComparer()
            => new NullableComparer<DateTime>(GetDateTimeAccurateToSecondsComparer());

        class NullableComparer<T> : IEqualityComparer<T?> where T : struct
        {
            readonly IEqualityComparer<T> wrapped;

            public bool Equals(T? x, T? y)
            {
                if(x.HasValue != y.HasValue) return false;
                if(x.HasValue && y.HasValue) return wrapped.Equals(x.Value, y.Value);
                return true;
            }

            public int GetHashCode(T? obj)
            {
                return obj.HasValue ? wrapped.GetHashCode(obj.Value) : 0;
            }

            public NullableComparer(IEqualityComparer<T> wrapped)
            {
                this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            }
        }
    }
}

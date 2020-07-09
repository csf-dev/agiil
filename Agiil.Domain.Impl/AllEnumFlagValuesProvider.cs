using System;
using System.Linq;
using System.Reflection;

namespace Agiil.Domain
{
    public class AllEnumFlagValuesProvider : IGetsAllEnumFlags
    {
        public T GetValueWithAllFlags<T>() where T : struct
        {
            if(!typeof(T).IsEnum || typeof(T).GetCustomAttribute<FlagsAttribute>() == null)
                throw new InvalidOperationException($"The generic type must be an enum decorated by {nameof(FlagsAttribute)}, but {typeof(T).Name} is not.");

            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return values.Aggregate(default(T), ReduceByBinaryOr);
        }

        /// <summary>
        /// The simplest way to reduce the enum values generically is to use <c>dynamic</c>.
        /// </summary>
        /// <returns>The reduced enum values.</returns>
        /// <param name="acc">Accumulate.</param>
        /// <param name="next">Next.</param>
        /// <typeparam name="T">The enum type.</typeparam>
        T ReduceByBinaryOr<T>(T acc, T next) where T : struct
        {
            dynamic first = acc;
            dynamic second = next;
            return (T) first | second;
        }
    }
}

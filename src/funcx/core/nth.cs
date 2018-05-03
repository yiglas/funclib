namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        /// <summary>
        /// Returns the value at the index. 
        /// </summary>
        /// <param name="coll">The <see cref="object"/> object.</param>
        /// <param name="index">The index to retrieve from the object.</param>
        /// <returns>
        /// The found object at the given index.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">If index is out of bounds.</exception>
        /// <exception cref="InvalidOperationException">If the object can't be indexed.</exception>
        public static object nth(object coll, int index)
        {
            if (!(coll is ValueType) && coll == null) return null;
            else if (coll is string str)
            {
                if (index < str.Length) return str[index];
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (coll.GetType().IsArray)
            {
                var result = ((IEnumerable)coll)
                    .Cast<object>()
                    .Select((x, i) => new { Index = i, Val = x })
                    .FirstOrDefault(x => x.Index == index)
                    ?.Val;

                if (result == null)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return result;
            }
            else if (coll is IList list) return list[index];
            else if (coll is Match match) return match.Groups[index];
            else if (coll is DictionaryEntry de)
            {
                if (index == 0) return de.Key;
                else if (index == 1) return de.Value;
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (coll is IEnumerable)
            {
                var s = seq(coll);
                for (int i = 0; i <= index && s != null; ++i, s = next(s))
                {
                    if (i == index)
                        return first(s);
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            throw new InvalidOperationException($"nth not supported on this type: {coll.GetType().FullName}");
        }

        /// <summary>
        /// Returns the value at the index. 
        /// </summary>
        /// <param name="coll">The <see cref="object"/> object.</param>
        /// <param name="index">The index to retrieve from the object.</param>
        /// <param name="notFound">what to return if index isn't found.</param>
        /// <returns>
        /// The found object at the given index.
        /// </returns>
        public static object nth(object coll, int index, object notFound)
        {
            if (!(coll is ValueType) && coll == null) return notFound;
            else if (coll is string str) return index < str.Length ? str[index] : notFound;
            else if (coll.GetType().IsArray)
                return ((IEnumerable)coll)
                    .Cast<object>()
                    .Select((x, i) => new { Index = i, Val = x })
                    .FirstOrDefault(x => x.Index == index)
                    ?.Val ?? notFound;
            else if (coll is IList list) return index < list.Count ? list[index] : notFound;
            else if (coll is Match match) return index < match.Groups.Count ? match.Groups[index] : notFound;
            else if (coll is DictionaryEntry de)
            {
                if (index == 0) return de.Key;
                else if (index == 1) return de.Value;
                return notFound;
            }
            else if (coll is IEnumerable)
            {
                var s = seq(coll);
                for (int i = 0; i <= index && s != null; ++i, s = next(s))
                {
                    if (i == index)
                        return first(s);
                }
                return notFound;
            }

            return notFound;
        }
    }
}

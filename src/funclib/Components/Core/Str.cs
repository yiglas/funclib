using funclib.Collections;
using System;
using System.Globalization;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// With no args, returns empty string. With one arg, returns arg.ToString(). If 
    /// arg is null return empty string. With more than one arg, returns the concatenation 
    /// of args.
    /// </summary>
    public class Str :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// With no args, returns empty string. With one arg, returns arg.ToString(). If 
        /// arg is null return empty string. With more than one arg, returns the concatenation 
        /// of args.
        /// </summary>
        /// <returns>
        /// Returns <see cref="string.Empty"/>.
        /// </returns>
        public object Invoke() => "";
        /// <summary>
        /// With no args, returns empty string. With one arg, returns arg.ToString(). If 
        /// arg is null return empty string. With more than one arg, returns the concatenation 
        /// of args.
        /// </summary>
        /// <param name="x">Object to convert into a string.</param>
        /// <returns>
        /// Returns <see cref="string.Empty"/> if x is null, otherwise <see cref="object.ToString()"/>.
        /// </returns>
        public object Invoke(object x) => x == null ? "" : string.Format(CultureInfo.InvariantCulture, "{0}", x);
        /// <summary>
        /// With no args, returns empty string. With one arg, returns arg.ToString(). If 
        /// arg is null return empty string. With more than one arg, returns the concatenation 
        /// of args.
        /// </summary>
        /// <param name="x">First object to convert into a string.</param>
        /// <param name="ys">Rest of the object to convert into a string.</param>
        /// <returns>
        /// Returns the concatenation of args into a single <see cref="string"/>.
        /// </returns>
        public object Invoke(object x, params object[] ys)
        {
            return inner(new StringBuilder((string)Invoke(x)), (ISeq)seq(ys)).ToString();

            StringBuilder inner(StringBuilder sb, ISeq more)
            {
                if (more != null)
                {
                    return inner(sb.Append(Invoke(more.First())), more.Next());
                }
                return sb;
            }
        }
    }
}

using funclib.Collections;
using System;
using System.Globalization;
using System.Text;

namespace funclib.Components.Core
{
    public class Str :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke() => "";
        public object Invoke(object x) => x == null ? "" : string.Format(CultureInfo.InvariantCulture, "{0}", x);
        public object Invoke(object x, params object[] ys)
        {
            return inner(new StringBuilder((string)Invoke(x)), (ISeq)new Seq().Invoke(ys)).ToString();

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

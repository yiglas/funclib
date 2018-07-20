using funclib.Collections;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Prints the object(s) to the <see cref="Variables.Out"/> stream.
    /// </summary>
    public class Print :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Prints the object(s) to the <see cref="Variables.Out"/> stream.
        /// </summary>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke() => null;
        /// <summary>
        /// Prints the object(s) to the <see cref="Variables.Out"/> stream.
        /// </summary>
        /// <param name="x">Object to print.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object x) { Pr(x, Variables.Out); return null; }
        /// <summary>
        /// Prints the object(s) to the <see cref="Variables.Out"/> stream.
        /// </summary>
        /// <param name="x">First object to print.</param>
        /// <param name="more">Rest of the object to print.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object x, params object[] more)
        {
            Invoke(x);
            Variables.Out.Write(' ');
            var nmore = new Next().Invoke(more);
            if ((bool)new Truthy().Invoke(nmore))
                return Invoke(new First().Invoke(more), nmore);

            return apply(this, more);
        }

        void Pr(object x, TextWriter w)
        {
            switch (x)
            {
                case double d: Pr(d, w); break;
                case float f: Pr(f, w); break;
                case short s: PrintDefault(s, w); break;
                case int i: PrintDefault(i, w); break;
                case long l: PrintDefault(l, w); break;
                case ushort us: PrintDefault(us, w); break;
                case uint ui: PrintDefault(ui, w); break;
                case ulong ul: PrintDefault(ul, w); break;
                case byte b: PrintDefault(b, w); break;
                case sbyte sb: PrintDefault(sb, w); break;
                case bool bl: w.Write(bl ? "true" : "false"); break;
                case string str: Pr(str, w); break;
                case char c: Pr(c, w); break;
                case Type t: Pr(t, w); break;
                case Regex regex: Pr(regex, w); break;
                case ISeq seq: Pr(seq, w); break;
                case IVector v: Pr(v, w); break;
                case IMap m: Pr(m, w); break;
                case ISet set: Pr(set, w); break;
                case IDeref deref: Pr(deref, w); break;
                case StackFrame sf: Pr(sf, w); break;
                case Exception ex: Pr(ex, w); break;
                case DateTime dt: Pr(dt, w); break;
                case DateTimeOffset dto: Pr(dto, w); break;
                case Guid g: Pr(g, w); break;
                case TimeSpan ts: Pr(ts, w); break;
                //case System.Collections.IDictionary dict: Pr(dict, w); break;
                //case System.Collections.ICollection coll: Pr(coll, w); break;
                case ValueType vt: PrintDefault(vt, w); break;
                default:
                    PrintObject(x, w);
                    break;
            }
        }

        string FPStr(object x)
        {
            var s = (string)new Str().Invoke(x);
            if ((bool)new Truthy().Invoke(new Or().Invoke(s.Contains("."), s.Contains("E"))))
                return s;

            return $"{s}.0";
        }


        void PrintDefault(object o, TextWriter w) => w.Write(new Str().Invoke(o));
        void Pr(double o, TextWriter w)
        {
            if (o == double.PositiveInfinity) Pr("##Inf", w);
            else if (o == double.NegativeInfinity) Pr("##-Inf", w);
            else if (double.IsNaN(o)) Pr("##NaN", w);
            else Pr(FPStr(o), w);
        }
        void Pr(float o, TextWriter w)
        {
            if (o == float.PositiveInfinity) Pr("##Inf", w);
            else if (o == float.NegativeInfinity) Pr("##-Inf", w);
            else if (float.IsNaN(o)) Pr("##NaN", w);
            else Pr(FPStr(o), w);
        }
        void Pr(DateTime o, TextWriter w) => w.Write($"#inst \"{o.ToString("yyyy-MM-ddTHH:mm:ss.fff-00:00")}\"");
        void Pr(DateTimeOffset o, TextWriter w) => w.Write($"#inst \"{o.ToString("yyyy-MM-ddTHH:mm:ss.fffzzzz")}\"");
        void Pr(Guid o, TextWriter w) => w.Write($"#uuid \"{o}\"");
        void Pr(TimeSpan o, TextWriter w) => w.Write(o.ToString());
        void PrintObject(object o, TextWriter w)
        {
            w.Write("#object[");
            var c = (Type)new Class().Invoke(o);
            if (c.IsArray)
            {
                Pr(c.Name, w);
            }
            else w.Write(c.Name);

            w.Write(" ");
            w.Write(o.GetHashCode());
            Pr(o.ToString(), w);
            w.Write("]");
        }
        void Pr(string o, TextWriter w) => w.Write(o);
        void Pr(Type o, TextWriter w) => w.Write(o.FullName);
        void Pr(char o, TextWriter w) => w.Write($"\\{o}");
        void Pr(Regex o, TextWriter w)
        {
            w.Write("#\"");
            w.Write(o.ToString());
            w.Write("\"");
        }
        void Pr(ISeq o, TextWriter w) => w.Write(o.ToString());
        void Pr(IVector o, TextWriter w) => w.Write(o.ToString());
        void Pr(IMap o, TextWriter w) => w.Write(o.ToString());
        void Pr(ISet o, TextWriter w) => w.Write(o.ToString());
        void Pr(IDeref o, TextWriter w) => throw new NotImplementedException();
        void Pr(StackFrame o, TextWriter w) => throw new NotImplementedException();
        void Pr(Exception o, TextWriter w) => throw new NotImplementedException();
        void Pr(System.Collections.IDictionary o, TextWriter w) => w.Write(Util.Print(o));
        void Pr(System.Collections.ICollection o, TextWriter w) => throw new NotImplementedException();
    }
}

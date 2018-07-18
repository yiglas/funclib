namespace funclib
{
    using funclib.Collections;
    using funclib.Collections.Internal;
    using funclib.Components.Core;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    static class Util
    {
        internal static int GetHashCode(object o) => o == null ? 0 : o.GetHashCode();
        internal static int GetHash(object o) => GetHashCode(o);

        internal static int BitCount(int x)
        {
            x -= ((x >> 1) & 0x55555555);
            x = (((x >> 2) & 0x33333333) + (x & 0x33333333));
            x = (((x >> 4) + x) & 0x0f0f0f0f);
            unchecked
            {
                return ((x * 0x01010101) >> 24);
            }
        }

        internal static int Mask(int hash, int shift) => (hash >> shift) & 0x01f;

        internal static int Bitpos(int hash, int shift) => 1 << Util.Mask(hash, shift);

        internal static INode[] CloneAndSet(INode[] array, int i, INode a)
        {
            var clone = array.Clone() as INode[];
            clone[i] = a;
            return clone;
        }

        internal static object[] CloneAndSet(object[] array, int i, object a)
        {
            var clone = array.Clone() as object[];
            clone[i] = a;
            return clone;
        }

        internal static object[] CloneAndSet(object[] array, int i, object a, int j, object b)
        {
            var clone = array.Clone() as object[];
            clone[i] = a;
            clone[j] = b;
            return clone;
        }

        internal static object[] RemovePair(object[] array, int i)
        {
            var newArray = new object[array.Length - 2];
            System.Array.Copy(array, 0, newArray, 0, 2 * i);
            System.Array.Copy(array, 2 * (i + 1), newArray, 2 * i, newArray.Length - 2 * i);
            return newArray;
        }

        internal static INode CreateNode(int shift, object key1, object val1, int key2hash, object key2, object val2)
        {
            int key1hash = GetHash(key1);
            if (key1hash == key2hash)
                return new HashCollisionNode(null, key1hash, 2, new object[] { key1, val1, key2, val2 });
            var _ = new Box(null);
            var edit = new AtomicReference<Thread>();
            return BitmapIndexedNode.EMPTY
                .Assoc(edit, shift, key1hash, key1, val1, _)
                .Assoc(edit, shift, key2hash, key2, val2, _);
        }

        internal static INode CreateNode(AtomicReference<Thread> edit, int shift, Object key1, Object val1, int key2hash, Object key2, Object val2)
        {
            int key1hash = GetHash(key1);
            if (key1hash == key2hash)
                return new HashCollisionNode(null, key1hash, 2, new object[] { key1, val1, key2, val2 });
            var _ = new Box(null);
            return BitmapIndexedNode.EMPTY
                .Assoc(edit, shift, key1hash, key1, val1, _)
                .Assoc(edit, shift, key2hash, key2, val2, _);
        }

        internal static string Print(object x)
        {
            using (var sw = new StringWriter())
            {
                Print(x, sw);
                return sw.ToString();
            }
        }

        internal static void Print(object x, TextWriter w)
        {
            if (x == null)
                w.Write("null");
            else if (x is ISeq || x is IList)
            {
                w.Write('(');
                PrintInnerSeq((ISeq)new Seq().Invoke(x), w);
                w.Write(')');
            }
            else if (x is string s)
            {
                w.Write('"');
                PrintInnerString(s, w);
                w.Write('"');
            }
            else if (x is IMap m)
            {
                w.Write('{');
                PrintInnerMap(m, w);
                w.Write('}');
            }
            else if (x is IVector v)
            {
                w.Write('[');
                PrintInnerVector(v, w);
                w.Write(']');
            }
            else if (x is ISet set)
            {
                w.Write("#{");
                PrintInnerSet(set, w);
                w.Write('}');
            }
            else if (x is char c)
            {
                w.Write('\\');
                PrintInnerChar(c, w, true);
            }
            else if (x is Regex r)
            {
                w.Write($"#\"{r.ToString()}\"");
            }
            else if (x is double || x is float)
            {
                var n = x.ToString();
                if (!n.Contains(".") && !n.Contains("E"))
                    n = n + ".0";
                w.Write(n);
            }
            else
                w.Write(x.ToString());
        }

        static void PrintInnerSeq(ISeq seq, TextWriter w)
        {
            for (var s = seq; s != null; s = s.Next())
            {
                Print(s.First(), w);
                if (s.Next() != null)
                    w.Write(' ');
            }
        }

        static void PrintInnerString(string s, TextWriter w)
        {
            foreach (var c in s)
            {
                PrintInnerChar(c, w);
            }
        }

        static void PrintInnerChar(char c, TextWriter w, bool printWord = false)
        {
            switch (c)
            {
                case '\n': w.Write(printWord ? "newline" : "\\n"); break;
                case '\t': w.Write(printWord ? "tab" : "\\t"); break;
                case '\r': w.Write(printWord ? "return" : "\\r"); break;
                case '"': w.Write("\\\""); break;
                case '\\': w.Write("\\\\"); break;
                case '\f': w.Write(printWord ? "formfeed" : "\\f"); break;
                case '\b': w.Write(printWord ? "backspace" : "\\b"); break;
                case ' ': w.Write(printWord ? "space" : " "); break;
                default:
                    w.Write(c); break;
            }
        }

        static void PrintInnerMap(IMap x, TextWriter w)
        {
            for (var s = x.Seq(); s != null; s = s.Next())
            {
                var e = (KeyValuePair)s.First();
                Print(e.Key, w);
                w.Write(' ');
                Print(e.Value, w);
                if (s.Next() != null)
                    w.Write(", ");
            }
        }

        static void PrintInnerVector(IVector v, TextWriter w)
        {
            int n = v.Count;
            for (int i = 0; i < n; i++)
            {
                Print(v[i], w);
                if (i < n - 1)
                    w.Write(' ');
            }
        }

        static void PrintInnerSet(ISet set, TextWriter w)
        {
            for(var s = set.Seq(); s != null; s = s.Next())
            {
                Print(s.First(), w);
                if (s.Next() != null)
                    w.Write(' ');
            }
        }
    }
}

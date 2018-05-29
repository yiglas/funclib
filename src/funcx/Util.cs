namespace funcx
{
    using funcx.Collections;
    using funcx.Collections.Internal;
    using funcx.Core;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using _ = funcx.core;

    static class Util
    {
        internal static R Reduce1<T, R>(Func<R, T, R> f, IEnumerable<T> coll)
        {
            if (_.truthy(coll))
            {
                return Reduce1(f, (R)Convert.ChangeType(_.first(coll), typeof(R)), _.next(coll));
            }

            return default;
        }

        internal static R Reduce1<T, R>(Func<R, T, R> f, R val, IEnumerable<T> coll)
        {
            if (_.truthy(coll))
            {
                return Reduce1(f, f(val, _.first(coll)), _.next(coll));
            }

            return val;
        }



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
            Array.Copy(array, 0, newArray, 0, 2 * i);
            Array.Copy(array, 2 * (i + 1), newArray, 2 * i, newArray.Length - 2 * i);
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
    }
}

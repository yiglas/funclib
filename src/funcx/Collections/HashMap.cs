﻿using funcx.Collections.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public class HashMap :
        Map
    {
        public static readonly HashMap EMPTY = new HashMap(0, null, false, null);
        static readonly object NOT_FOUND = new object();

        readonly int _count;

        HashMap(int count, INode root, bool hasNull, object nullValue)
        {
            this._count = count;
            Root = root;
            HasNull = hasNull;
            NullValue = nullValue;
        }

        internal INode Root { get; }

        internal bool HasNull { get; }

        internal object NullValue { get; }

        #region Creates
        public static IMap Create(System.Collections.IDictionary init)
        {
            var ret = (ITransientMap)EMPTY.ToTransient();

            foreach (System.Collections.DictionaryEntry e in init)
                ret = ret.Assoc(e.Key, e.Value);

            return ret.ToPersistent();
        }

        public static IMap Create(params object[] init)
        {
            var ret = (ITransientMap)EMPTY.ToTransient();

            for (int i = 0; i < init.Length; i += 2)
            {
                ret = ret.Assoc(init[i], init[i + 1]);
                if (ret.Count != i / 2 + 1)
                    throw new ArgumentException($"Duplicate key: {init[i]}");
            }

            return ret.ToPersistent();
        }

        public static IMap Create(System.Collections.IEnumerable init)
        {
            var ret = (ITransientMap)EMPTY.ToTransient();
            var counter = ret.Count;

            for (System.Collections.IEnumerator i = init.GetEnumerator(); i.MoveNext();)
            {
                object key = i.Current;
                if (!i.MoveNext())
                    throw new ArgumentException($"No value supplied for key: {key}");

                object value = i.Current;

                ret = ret.Assoc(key, value);
                if (ret.Count == counter)
                    throw new ArgumentException($"Duplicate key: {key}");

                counter = ret.Count;
            }

            return ret.ToPersistent();
        }
        #endregion

        #region Overrides
        public override int Count => this._count;

        public override IMap Assoc(object key, object val)
        {
            if (key == null)
            {
                if (HasNull && val == NullValue) return this;

                return new HashMap(HasNull ? this._count : this._count + 1, Root, true, val);
            }

            var addedLeaf = new Box(null);
            var root = (Root ?? BitmapIndexedNode.EMPTY).Assoc(0, Hash(key), key, val, addedLeaf);

            return root == Root
                ? this
                : new HashMap(addedLeaf.Value == null ? this._count : this._count + 1, root, HasNull, NullValue);
        }

        public override bool ContainsKey(object key) =>
            key == null
                ? HasNull
                : Root != null ? Root.Get(0, Hash(key), key, NOT_FOUND) != NOT_FOUND
                : false;

        public override ICollection Empty() => EMPTY;

        public override KeyValuePair<object, object>? Get(object key)
        {
            if (key == null)
            {
                if (HasNull)
                {
                    return new KeyValuePair<object, object>(null, NullValue);
                }

                return null;
            }

            if (Root != null)
                return Root.Get(0, Hash(key), key);

            return null;
        }
        public override object GetValue(object key) => GetValue(key, null);
        public override object GetValue(object key, object notFound) =>
            key == null
                ? HasNull ? NullValue
                : notFound
                : Root != null ? Root.Get(0, Hash(key), key, notFound)
                : notFound;

        public override ITransientCollection ToTransient() => new TransientHashMap(this);
        public override IMap Without(object key)
        {
            if (key == null)
                return HasNull ? new HashMap(this._count - 1, Root, false, null) : this;
            if (Root == null) return this;

            var root = Root.Without(0, Hash(key), key);
            if (Root == root) return this;

            return new HashMap(this._count - 1, root, HasNull, NullValue);
        }
        public override IEnumerative Enumerate()
        {
            var e = Root?.GetNodeEnumerative();
            return HasNull
                ? new Cons(new KeyValuePair<object, object>(null, NullValue), e)
                : e;
        }
        public override IEnumerator GetKeyEnumerator() => MakeEnumerator((k, v) => k);
        public override IEnumerator GetValueEnumerator() => MakeEnumerator((k, v) => v);
        #endregion

        int Hash(object key) => Util.GetHashCode(key);

        public IEnumerator MakeEnumerator(Func<object, object, object> d)
        {
            var iter = Root?.GetEnumerator(d) ?? EmptyEnumerator();
            if (!HasNull)
                return iter;

            return NullEnumerator(d, NullValue, iter);
        }

        IEnumerator EmptyEnumerator()
        {
            yield break;
        }

        IEnumerator NullEnumerator(Func<object, object, object> d, object nullValue, IEnumerator root)
        {
            yield return d(null, nullValue);
            while (root.MoveNext())
                yield return root.Current;
        }
    }
}

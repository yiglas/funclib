using System;
using funclib.Collections.Generic.Internal;

namespace funclib.Collections.Generic
{
    public class HashMap<TKey, TValue> :
        AMap<TKey, TValue>,
        IReduceKV<TKey, TValue>
    {
        public static readonly HashMap<TKey, TValue> EMPTY = new HashMap<TKey, TValue>(0, null, false, default);

        readonly int _count;

        internal HashMap(int count, INode<TKey, TValue> root, bool hasNull, TValue nullValue)
        {
            this._count = count;
            Root = root;
            HasNull = hasNull;
            NullValue = nullValue;
        }

        internal INode<TKey, TValue> Root { get; }

        internal bool HasNull { get; }

        internal TValue NullValue { get; }

        #region Creates
        public static IMap<TKey, TValue> Create(System.Collections.Generic.IDictionary<TKey, TValue> init)
        {
            var ret = (ITransientMap<TKey, TValue>)EMPTY.ToTransient();

            foreach (var e in init)
                ret = ret.Assoc(e.Key, e.Value);

            return ret.ToPersistent();
        }

        public static IMap<TKey, TValue> Create(params UnionType<TKey, TValue>[] init)
        {
            var ret = (ITransientMap<TKey, TValue>)EMPTY.ToTransient();

            for (int i = 0; i < init.Length; i += 2)
            {
                ret = ret.Assoc(init[i], init[i + 1]);
                if (ret.Count != i / 2 + 1)
                    throw new ArgumentException($"Duplicate key: {init[i]}");
            }

            return ret.ToPersistent();
        }

        public static IMap<TKey, TValue> Create(params (TKey Key, TValue Value)[] init)
        {
            var ret = (ITransientMap<TKey, TValue>)EMPTY.ToTransient();

            for (int i = 0; i < init.Length; i++)
            {
                var kvp = init[i];
                ret = ret.Assoc(kvp.Key, kvp.Value);
                if (ret.Count != i)
                {
                    throw new ArgumentException($"Duplicate key: {kvp.Key}");
                }
            }

            return ret.ToPersistent();
        }

        public static IMap<TKey, TValue> Create(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>> init)
        {
            var ret = (ITransientMap<TKey, TValue>)EMPTY.ToTransient();
            var counter = ret.Count;

            foreach (var item in init)
            {
                ret = ret.Assoc(item.Key, item.Value);
                if (ret.Count == counter)
                {
                    throw new ArgumentException($"Duplicate key: {item.Key}");
                }
            }

            return ret.ToPersistent();
        }
        #endregion

        #region Overrides
        public override int Count => this._count;

        public override IMap<TKey, TValue> Assoc(TKey key, TValue val)
        {
            if (key is null)
            {
                if (HasNull && val is null)
                {
                    return this;
                }

                return new HashMap<TKey, TValue>(HasNull ? this._count : this._count + 1, Root, true, val);
            }

            var addedLeaf = new Box<object>(null);
            var root = (Root ?? BitmapIndexedNode<TKey, TValue>.EMPTY).Assoc(0, Hash(key), key, val, addedLeaf);

            if (root == Root)
            {
                return this;
            }

            return new HashMap<TKey, TValue>(addedLeaf.Value is null ? this._count : this._count + 1, root, HasNull, NullValue);
        }

        public override bool ContainsKey(TKey key)
        {
            if (key is null)
            {
                return HasNull;
            }

            if (Root != null)
            {
                return Root.Get(0, Hash(key), key) == null;
            }

            return false;
        }

        public override ICollection<IKeyValuePair<TKey, TValue>> Empty() => EMPTY;

        public override IKeyValuePair<TKey, TValue> Get(TKey key)
        {
            if (key is null)
            {
                if (HasNull)
                {
                    return KeyValuePair<TKey, TValue>.Create(default, NullValue);
                }

                return null;
            }

            if (Root != null)
            {
                return Root.Get(0, Hash(key), key);
            }

            return null;
        }
        public override TValue GetValue(TKey key)
        {
            if (key is null)
            {
                if (HasNull)
                {
                    return NullValue;
                }

                return default;
            }

            if (Root != null)
            {
                return Root.Get(0, Hash(key), key).Value;
            }

            return default;
        }

        public override TValue GetValue(TKey key, TValue notFound)
        {
            if (key is null)
            {
                if (HasNull)
                {
                    return NullValue;
                }

                return notFound;
            }

            if (Root != null)
            {
                return Root.Get(0, Hash(key), key, notFound);
            }

            return notFound;
        }


        public override System.Collections.Generic.IEnumerator<TKey> GetKeyEnumerator() => MakeEnumerator((k, v) => k);

        public override System.Collections.Generic.IEnumerator<TValue> GetValueEnumerator() => MakeEnumerator((k, v) => v);

        #endregion

        public TResult ReduceKV<TResult>(Func<TResult, TKey, TValue, TResult> f, TResult init)
        {
            if (HasNull)
            {
                init = f(init, default, NullValue);
            }

            if (Root != null)
            {
                Func<TResult, UnionType<TKey, TValue, INode<TKey, TValue>>, UnionType<TKey, TValue, INode<TKey, TValue>>, TResult> fn = (i, k, v) => f(i, k, v);

                init = Root.Reduce(fn, init);

                return init;
            }

            return init;
        }

        public override ISeq<IKeyValuePair<TKey, TValue>> Seq()
        {
            var e = Root?.GetNodeEnumerative();

            if (HasNull)
            {
                return new Cons<IKeyValuePair<TKey, TValue>>(KeyValuePair<TKey, TValue>.Create(null, NullValue), e);
            }

            return e;
        }

        public override ITransientCollection<IKeyValuePair<TKey, TValue>> ToTransient() => new TransientHashMap<TKey, TValue>(this);

        public override IMap<TKey, TValue> Without(TKey key)
        {
            if (key is null)
            {
                if (HasNull)
                {
                    new HashMap<TKey, TValue>(this._count - 1, Root, false, null);
                }
                return this;
            }
            if (Root is null) return this;

            var root = Root.Without(0, Hash(key), key);
            if (Root == root)
            {
                return this;
            }

            return new HashMap<TKey, TValue>(this._count - 1, root, HasNull, NullValue);
        }

        int Hash(object key) => Util.GetHashCode(key);

        System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> MakeEnumerator(Func<TKey, UnionType<TValue, INode<TKey, TValue>>, IKeyValuePair<TKey, TValue>> d)
        {
            var iter = Root?.GetEnumerator(d) ?? EmptyEnumerator();
            if (!HasNull)
            {
                return iter;
            }

            return NullEnumerator(d, NullValue, iter);
        }

        System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> EmptyEnumerator()
        {
            yield break;
        }

        System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> NullEnumerator(Func<TKey, UnionType<TValue, INode<TKey, TValue>>, IKeyValuePair<TKey, TValue>> d, TValue nullValue, System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> root)
        {
            yield return d(null, nullValue);

            while (root.MoveNext())
            {
                yield return root.Current;
            }
        }
    }
}
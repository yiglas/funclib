using System;
using System.Linq;
using funclib.Collections.Generic.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic
{
    public abstract class AMap<TKey, TValue> :
        IMap<TKey, TValue>,
        IFunction<TKey, TValue>,
        IFunction<TKey, TValue, TValue>
        where TValue : new()
    {
        int _hash;
        static readonly TValue _missingValue = new TValue();

        public TValue this[TKey key] { get => GetValue(key); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}."); }
        public bool IsSynchronized => true;
        public object SyncRoot => this;
        public bool IsFixedSize => true;
        public bool IsReadOnly => true;

        #region Overrides
        public override string ToString() => Util.Print(this);

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj is System.Collections.Generic.IDictionary<TKey, TValue> d)
            {
                if (Count != d.Count) return false;

                for (var e = Seq(); e != null; e = e.Next())
                {
                    var de = e.First();
                    bool found = d.ContainsKey(de.Key);
                    if (!found || !funclib.Generic.Core.IsEqualTo(de.Value, d[de.Key]))
                    {
                        return false;
                    }
                }
            }
            else
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            if (this._hash == 0)
            {
                this._hash = getHashCode(this);
            }

            return this._hash;

            int getHashCode(IMap<TKey, TValue> m)
            {
                int hash = 0;
                for (var e = Seq(); e != null; e = e.Next())
                {
                    var de = e.First();

                    hash += de.Key?.GetHashCode() ?? 0 ^ de.Value?.GetHashCode() ?? 0;
                }
                return hash;
            }
        }
        #endregion

        #region Invalid Operations
        public void Add(IKeyValuePair<TKey, TValue> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public void Add(TKey key, TValue value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public bool Remove(IKeyValuePair<TKey, TValue> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public bool Remove(TKey key) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        #endregion

        #region Abstract Methods
        public abstract int Count { get; }
        public abstract ICollection<IKeyValuePair<TKey, TValue>> Empty();
        public abstract bool ContainsKey(TKey key);
        public abstract IKeyValuePair<TKey, TValue> Get(TKey key);
        public abstract TValue GetValue(TKey key);
        public abstract TValue GetValue(TKey key, TValue notFound);
        public abstract IMap<TKey, TValue> Assoc(TKey key, TValue val);
        public abstract IMap<TKey, TValue> Without(TKey key);
        public abstract ITransientCollection<IKeyValuePair<TKey, TValue>> ToTransient();
        public abstract ISeq<IKeyValuePair<TKey, TValue>> Seq();
        public abstract System.Collections.Generic.IEnumerator<TKey> GetKeyEnumerator();
        public abstract System.Collections.Generic.IEnumerator<TValue> GetValueEnumerator();
        #endregion

        #region Virtual Methods
        public virtual System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (var e = Seq(); e != null; e.Next())
            {
                var entry = e.First();
                yield return new KeyValuePair(entry.Key, entry.Value) as IKeyValuePair<TKey, TValue>;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (var e = Seq(); e != null; e = e.Next())
            {
                var entry = e.First();
                yield return new KeyValuePair<TKey, TValue>(entry.Key, entry.Value);
            }
        }
        #endregion

        #region Functions
        public TValue Invoke(TKey key) => GetValue(key);
        public TValue Invoke(TKey key, TValue notFound) => GetValue(key, notFound);
        #endregion

        public System.Collections.Generic.ICollection<TKey> Keys => KeySeq<TKey, TValue>.Create(Seq());

        public System.Collections.Generic.ICollection<TValue> Values => ValueSeq<TKey, TValue>.Create(Seq());



        public IMap<TKey, TValue> Cons(IKeyValuePair<TKey, TValue> o)
        {
            if (o is KeyValuePair<TKey, TValue> kvp)
            {
                return Assoc(kvp.Key, kvp.Value);
            }
            else if (o is System.Collections.Generic.KeyValuePair<TKey, TValue> de)
            {
                return Assoc(de.Key, de.Value);
            }
            else if (o is IVector<UnionType<TKey, TValue>> v)
            {
                if (v.Count != 2)
                {
                    throw new ArgumentException("Vector arg to map cons must be a pair.");
                }

                return Assoc(v[0], v[1]);
            }
            else if (o is System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> e)
            {
                return Cons(e);
            }

            return this;
        }

        IMap<TKey, TValue> Cons(System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> e)
        {
            IMap<TKey, TValue> ret = this;
            foreach (var item in e)
            {
                ret = ret.Assoc(item.Key, item.Value);
            }
            return ret;
        }

        public bool Contains(IKeyValuePair<TKey, TValue> item) => ContainsKey(item.Key);

        public bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> item) => ContainsKey(item.Key);


        public void CopyTo(IKeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var e = Seq();
            if (e != null)
            {
                e.CopyTo(array, arrayIndex);
            }
        }

        public void CopyTo(System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var e = Seq();
            if (e != null)
            {
                e.CopyTo(array.Select(x => KeyValuePair<TKey, TValue>.Create(x.Key, x.Value)).ToArray(), arrayIndex);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (ContainsKey(key))
            {
                value = GetValue(key);
                return true;
            }

            value = default;
            return false;
        }

        IAssociative<TKey, TValue> IAssociative<TKey, TValue>.Assoc(TKey key, TValue val) => Assoc(key, val);
        ICollection<IKeyValuePair<TKey, TValue>> ICollection<IKeyValuePair<TKey, TValue>>.Cons(IKeyValuePair<TKey, TValue> o) => Cons(o);

        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>.GetEnumerator() => new MapEnumerator<TKey, TValue>(this);

        System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>>.GetEnumerator() => new MapEnumerator<TKey, TValue>(this);
    }
}
using System;

namespace funclib.Collections.Generic
{
    public abstract class AMap<TKey, TValue>  :
        IMap<TKey, TValue>
    {
         int _hash;
        static readonly TValue _missingValue = default; // TODO: make sure this has been implement correctly

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
                    if (!found || !funclib.Components.Core.Generic.Stuff.IsEqualTo(de.Value, d[de.Key]))
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            if (this._hash == 0)
                this._hash = getHashCode(this);

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
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public void Add(TKey key, TValue value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
        //void System.Collections.IDictionary.Remove(object key) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(AMap)}.");
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
        public virtual System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (var e = Seq(); e != null; e = e.Next())
            {
                var entry = e.First();
                yield return new KeyValuePair(entry.Key, entry.Value);
            }
        }
        #endregion

        #region Functions
        public object Invoke(object key) => GetValue(key);
        public object Invoke(object key, object notFound) => GetValue(key, notFound);
        #endregion


        public System.Collections.ICollection Keys => KeySeq.Create(Seq());

        public System.Collections.ICollection Values => ValueSeq.Create(Seq());

        public IMap Cons(object o) =>
            o is KeyValuePair kvp
                ? Assoc(kvp.Key, kvp.Value)
                : o is System.Collections.DictionaryEntry de ? Assoc(de.Key, de.Value)
                : o is IVector v ? v.Count != 2 ? throw new ArgumentException("Vector arg to map cons must be a pair.") : Assoc(v[0], v[1])
                : o is System.Collections.IEnumerable e ? Cons(e)
                : this;

        IMap Cons(System.Collections.IEnumerable e)
        {
            IMap ret = this;
            foreach (var item in e)
            {
                var kvp = (KeyValuePair)item;
                ret = ret.Assoc(kvp.Key, kvp.Value);
            }
            return ret;
        }


        public bool Contains(object item) => ContainsKey(item);

        public void CopyTo(object[] array, int arrayIndex)
        {
            var e = Seq();
            if (e != null)
                e.CopyTo(array, arrayIndex);
        }
        public void CopyTo(System.Array array, int index)
        {
            var e = Seq();
            if (e != null)
                e.CopyTo(array, index);
        }

        public bool TryGetValue(object key, out object value)
        {
            object found = GetValue(key, _missingValue);

            if (found == _missingValue)
            {
                value = null;
                return false;
            }

            value = found;
            return true;
        }
        ICollection ICollection.Cons(object o) => Cons(o);
        IAssociative IAssociative.Assoc(object key, object val) => Assoc(key, val);
        System.Collections.IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() => new MapEnumerator(this);
    }
}
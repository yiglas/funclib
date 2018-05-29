using funcx.Collections.Internal;
using funcx.Core;
using System;
using System.Text;

namespace funcx.Collections
{
    public abstract class Map:
        IMap,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        int _hash;
        static readonly object _missingValue = new object();

        public object this[object key] { get => GetValue(key); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}."); }
        public bool IsSynchronized => true;
        public object SyncRoot => this;
        public bool IsFixedSize => true;
        public bool IsReadOnly => true;

        #region Overrides
        public override string ToString() => base.ToString(); // TODO: implement to string method.

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj is System.Collections.IDictionary d)
            {
                if (Count != d.Count) return false;

                for (var e = Enumerate(); e != null; e = e.Next())
                {
                    var de = (System.Collections.Generic.KeyValuePair<object, object>)e.First();
                    bool found = d.Contains(de.Key);
                    if (!found || !new Core.Equals().Invoke(de.Value, d[de.Key]))
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

            int getHashCode(IMap m)
            {
                int hash = 0;
                for (var e = Enumerate(); e != null; e = e.Next())
                {
                    var de = (System.Collections.Generic.KeyValuePair<object, object>)e.First();

                    hash += de.Key?.GetHashCode() ?? 0 ^ de.Value?.GetHashCode() ?? 0;
                }
                return hash;
            }
        }
        #endregion

        #region Invalid Operations
        public void Add(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        public void Add(object key, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        public void Add(System.Collections.Generic.KeyValuePair<object, object> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        void System.Collections.IDictionary.Remove(object key) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        public bool Remove(object item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        public bool Remove(System.Collections.Generic.KeyValuePair<object, object> item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(Map)}.");
        #endregion

        #region Abstract Methods
        public abstract int Count { get; }
        public abstract ICollection Empty();
        public abstract bool ContainsKey(object key);
        public abstract System.Collections.Generic.KeyValuePair<object, object>? Get(object key);
        public abstract object GetValue(object key);
        public abstract object GetValue(object key, object notFound);
        public abstract IMap Assoc(object key, object val);
        public abstract IMap Without(object key);
        public abstract ITransientCollection ToTransient();
        public abstract IEnumerative Enumerate();
        public abstract System.Collections.IEnumerator GetKeyEnumerator();
        public abstract System.Collections.IEnumerator GetValueEnumerator();
        #endregion

        #region Virtual Methods
        public virtual System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object, object>> GetEnumerator()
        {
            for (var e = Enumerate(); e != null; e = e.Next())
            {
                var entry = (System.Collections.Generic.KeyValuePair<object, object>)e.First();
                yield return new System.Collections.Generic.KeyValuePair<object, object>(entry.Key, entry.Value);
            }
        }
        #endregion

        #region Functions
        public object Invoke(object key) => GetValue(key);
        public object Invoke(object key, object notFound) => GetValue(key, notFound);
        #endregion


        public System.Collections.ICollection Keys => KeyEnumerative.Create(Enumerate());

        public System.Collections.ICollection Values => throw new NotImplementedException();

        System.Collections.Generic.ICollection<object> System.Collections.Generic.IDictionary<object, object>.Keys => ValueEnumerative.Create(Enumerate());

        System.Collections.Generic.ICollection<object> System.Collections.Generic.IDictionary<object, object>.Values => ValueEnumerative.Create(Enumerate());

        public IMap Cons(object o) =>
            o is System.Collections.Generic.KeyValuePair<object, object> kvp
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
                var kvp = (System.Collections.Generic.KeyValuePair<object, object>)item;
                ret = ret.Assoc(kvp.Key, kvp.Value);
            }
            return ret;
        }


        public bool Contains(object item) => ContainsKey(item);
        public bool Contains(System.Collections.Generic.KeyValuePair<object, object> item) =>
            !TryGetValue(item.Key, out object value)
                ? false
                : value == null ? item.Value == null
                : value.Equals(item.Value);
        
        public void CopyTo(object[] array, int arrayIndex)
        {
            var e = Enumerate();
            if (e != null)
                e.CopyTo(array, arrayIndex);
        }
        public void CopyTo(Array array, int index)
        {
            var e = Enumerate();
            if (e != null)
                e.CopyTo(array, index);
        }
        public void CopyTo(System.Collections.Generic.KeyValuePair<object, object>[] array, int arrayIndex)
        {
            var e = Enumerate();
            if (e != null)
                e.CopyTo(array, arrayIndex);
        }


        public object First() => throw new NotImplementedException();
        public ICollection More() => throw new NotImplementedException();
        public ICollection Next() => throw new NotImplementedException();
        
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
        System.Collections.Generic.KeyValuePair<object, object>? IMap.First() => First() as System.Collections.Generic.KeyValuePair<object, object>?;
        IAssociative IAssociative.Assoc(object key, object val) => Assoc(key, val);
        System.Collections.IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() => new MapEnumerator(this);
        System.Collections.Generic.IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator() => ((System.Collections.Generic.IEnumerable<object>)this).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object, object>>)this).GetEnumerator();
    }
}

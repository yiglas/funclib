using funcx.Collections.Internal;
using funcx.Core;
using System;
using System.Text;

namespace funcx.Collections
{
    [Serializable]
    public abstract class Set:
        ISet,
        IFunction<object, object>
    {
        protected int _hash;
        protected IMap _impl;

        public int Count => this._impl.Count;
        public bool IsSynchronized => true;
        public object SyncRoot => this;
        public bool IsReadOnly => true;

        #region Overrides
        public override string ToString() => base.ToString(); // TODO: implement to string method.

        public override int GetHashCode()
        {
            int hash = this._hash;
            if (hash == 0)
            {
                foreach (var item in this)
                {
                    hash += Util.GetHashCode(item);
                }
                this._hash = hash;
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj is ISet set)
            {
                if (Count != set.Count) return false;

                foreach (var item in set)
                    if (!Contains(item))
                        return false;

                return true;
            }

            return false;
        }
        #endregion

        #region Invalid Operations
        public void Add(object item) => throw new InvalidOperationException("Cannot modify an immutable set.");
        public void Clear() => throw new InvalidOperationException("Cannot modify an immutable set.");
        public bool Remove(object item) => throw new InvalidOperationException("Cannot modify an immutable set.");
        #endregion

        #region Abstract Methods
        public abstract ICollection Cons(object o);
        public abstract ICollection Empty();
        public abstract ISet Disjoin(object key);
        public abstract ITransientCollection ToTransient();
        #endregion

        #region Functions
        public object Invoke(object key) => Get(key);
        #endregion

        public bool Contains(object key) => this._impl.ContainsKey(key);        
        public object Get(object key) => this._impl.GetValue(key);

        public void CopyTo(Array array, int index)
        {
            var e = Enumerate();
            if (e != null)
                e.CopyTo(array, index);
        }
        public void CopyTo(object[] array, int arrayIndex)
        {
            var e = Enumerate();
            if (e != null)
                e.CopyTo(array, arrayIndex);
        }

        public System.Collections.Generic.IEnumerator<object> GetEnumerator()
        {
            if (this._impl != null)
                this._impl.GetKeyEnumerator();

            yield break;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerative Enumerate() => KeyEnumerative.Create(this._impl.Enumerate());
    }
}

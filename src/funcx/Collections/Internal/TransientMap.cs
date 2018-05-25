using funcx.Core;
using System;
using System.Text;

namespace funcx.Collections.Internal
{
    abstract class TransientMap :
        ITransientMap,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        static readonly object NOT_FOUND = new object();

        #region Overrides
        #endregion

        #region Invalid Operations
        #endregion

        #region Abstract Methods
        protected abstract bool EnsureEditable();
        protected abstract ITransientMap DoAssoc(object key, object val);
        protected abstract ITransientMap DoWithout(object key);
        protected abstract object DoGetValue(object key, object notFound);
        protected abstract int DoCount();
        protected abstract IMap DoToPersistent();
        #endregion

        #region Functions
        public object Invoke(object key) => GetValue(key);
        public object Invoke(object key, object notFound) => GetValue(key, notFound);
        #endregion

        public int Count => EnsureEditable() ? DoCount() : -1;

        public ITransientMap Assoc(object key, object val) => EnsureEditable() ? DoAssoc(key, val) : null;
        public ITransientCollection Conj(object val) => ConjMap(val);

        public bool ContainsKey(object key) => GetValue(key, NOT_FOUND) != NOT_FOUND;
        public System.Collections.Generic.KeyValuePair<object, object>? Get(object key)
        {
            var v = GetValue(key, NOT_FOUND);

            if (v != NOT_FOUND)
                return new System.Collections.Generic.KeyValuePair<object, object>(key, v);

            return null;
        }
        public object GetValue(object key) => GetValue(key, null);
        public object GetValue(object key, object notFound) => EnsureEditable() ? DoGetValue(key, notFound) : notFound;
        public IMap ToPersistent() => EnsureEditable() ? DoToPersistent() : null;
        public ITransientMap Without(object key) => EnsureEditable() ? DoWithout(key) : null;
        ITransientAssociative ITransientAssociative.Assoc(object key, object val) => Assoc(key, val);
        ICollection ITransientCollection.ToPersistent() => ToPersistent();

        ITransientMap ConjMap(object val) =>
            EnsureEditable()
                ? val is System.Collections.Generic.KeyValuePair<object, object> kvp ? Assoc(kvp.Key, kvp.Value)
                : val is System.Collections.DictionaryEntry de ? Assoc(de.Key, de.Value)
                : val is IVector v ? v.Count != 2 ? throw new ArgumentException("Vector arg to map conj must be a pair.") : Assoc(v[0], v[1])
                : val is System.Collections.IEnumerable e ? ConjMap(e)
                : this
                : null;

        ITransientMap ConjMap(System.Collections.IEnumerable e)
        {
            ITransientMap ret = this;
            foreach (var item in e)
            {
                var kvp = (System.Collections.Generic.KeyValuePair<object, object>)item;
                ret = ret.Assoc(kvp.Key, kvp.Value);
            }
            return ret;
        }
    }
}

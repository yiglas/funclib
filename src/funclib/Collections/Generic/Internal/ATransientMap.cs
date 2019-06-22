using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic.Internal
{
    abstract class ATransientMap<TKey, TValue> :
        ITransientMap<TKey, TValue>,
        IFunction<TKey, TValue>,
        IFunction<TKey, TValue, TValue>
    {
        #region Overrides
        #endregion

        #region Invalid Operations
        #endregion

        #region Abstract Methods
        protected abstract bool EnsureEditable();
        protected abstract ITransientMap<TKey, TValue> DoAssoc(TKey key, TValue val);
        protected abstract ITransientMap<TKey, TValue> DoWithout(TKey key);
        protected abstract TValue DoGetValue(TKey key, TValue notFound);
        protected abstract int DoCount();
        protected abstract IMap<TKey, TValue> DoToPersistent();
        #endregion

        #region Functions
        public TValue Invoke(TKey key) => GetValue(key);
        public TValue Invoke(TKey key, TValue notFound) => GetValue(key, notFound);
        #endregion

        public int Count
        {
            get
            {
                if (EnsureEditable())
                {
                    return DoCount();
                }

                return -1;
            }
        }

        public ITransientMap<TKey, TValue> Assoc(TKey key, TValue val)
        {
            if (EnsureEditable())
            {
                return DoAssoc(key, val);
            }

            return null;
        }

        public ITransientCollection<IKeyValuePair<TKey, TValue>> Conj(IKeyValuePair<TKey, TValue> val)
        {
            if (EnsureEditable())
            {
                return Assoc(val.Key, val.Value);
            }

            return null;
        }

        public bool ContainsKey(TKey key) => GetValue(key, default) != default;

        public IKeyValuePair<TKey, TValue> Get(TKey key)
        {
            var v = GetValue(key, default);

            if (v != default)
            {
                return KeyValuePair<TKey, TValue>.Create(key, v);
            }

            return null;
        }

        public TValue GetValue(TKey key) => GetValue(key, default);

        public TValue GetValue(TKey key, TValue notFound)
        {
            if (EnsureEditable())
            {
                return DoGetValue(key, notFound);
            }

            return notFound;
        }

        public IMap<TKey, TValue> ToPersistent()
        {
            if (EnsureEditable())
            {
                return DoToPersistent();
            }

            return null;
        }

        public ITransientMap<TKey, TValue> Without(TKey key)
        {
            if (EnsureEditable())
            {
                return DoWithout(key);
            }

            return null;
        }

        ITransientAssociative<TKey, TValue> ITransientAssociative<TKey, TValue>.Assoc(TKey key, TValue val) => Assoc(key, val);

        ICollection<IKeyValuePair<TKey, TValue>> ITransientCollection<IKeyValuePair<TKey, TValue>>.ToPersistent() => ToPersistent();
    }
}
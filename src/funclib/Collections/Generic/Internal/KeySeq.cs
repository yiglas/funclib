using System;

namespace funclib.Collections.Generic.Internal
{
    sealed class KeySeq<TKey, TValue> :
        ASeq<TKey>,
        System.Collections.Generic.IEnumerable<TKey>
    {
        readonly ISeq<IKeyValuePair<TKey, TValue>> _enumerative;
        readonly System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> _enumerable;

        KeySeq(ISeq<IKeyValuePair<TKey, TValue>> enumerative, System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static KeySeq<TKey, TValue> Create(ISeq<IKeyValuePair<TKey, TValue>> enumerative)
        {
            if (enumerative is null)
            {
                return null;
            }

            return new KeySeq<TKey, TValue>(enumerative, null);
        }
        public static KeySeq<TKey, TValue> Create(IMap<TKey, TValue> map)
        {
            var enumerative = map?.Seq();
            if (enumerative is null)
            {
                return null;
            }

            return new KeySeq<TKey, TValue>(enumerative, map);
        }
        #endregion

        #region Overrides
        public override TKey First()
        {
            var entry = this._enumerative.First();

            if (entry is KeyValuePair<TKey, TValue> kvp)
            {
                return kvp.Key;
            }
            else if (entry is RedBlackNode<TKey, TValue> rbn)
            {
                return rbn.Key;
            }
            else if (entry is System.Collections.Generic.KeyValuePair<TKey, TValue> de)
            {
                return de.Key;
            }

            throw new InvalidCastException($"Unable to cast object of type '{entry.GetType().FullName}' to type '{typeof(KeyValuePair).FullName}'.");
        }
        public override ISeq<TKey> Next() => Create(this._enumerative.Next());
        public override IStack<TKey> Pop() => throw new NotImplementedException();

        public override System.Collections.Generic.IEnumerator<TKey> GetEnumerator()
        {
            if (this._enumerable is null)
            {
                return base.GetEnumerator();
            }

            if (this._enumerable is IMapEnumerable<TKey, TValue> m)
            {
                return m.GetKeyEnumerator();
            }

            return null;
        }
        #endregion
    }
}
using System;

namespace funclib.Collections.Generic.Internal
{
    sealed class ValueSeq<TKey, TValue> :
        ASeq<TValue>,
        System.Collections.Generic.IEnumerable<TValue>
    {
        readonly ISeq<IKeyValuePair<TKey, TValue>> _enumerative;
        readonly System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> _enumerable;

        ValueSeq(ISeq<IKeyValuePair<TKey, TValue>> enumerative, System.Collections.Generic.IEnumerable<IKeyValuePair<TKey, TValue>> enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static ValueSeq<TKey, TValue> Create(ISeq<IKeyValuePair<TKey, TValue>> enumerative)
        {
            if (enumerative is null)
            {
                return null;
            }

            return new ValueSeq<TKey, TValue>(enumerative, null);
        }

        public static ValueSeq<TKey, TValue> Create(IMap<TKey, TValue> map)
        {
            var enumerative = map?.Seq();
            if (enumerative is null)
            {
                return null;
            }

            return new ValueSeq<TKey, TValue>(enumerative, map);
        }
        #endregion

        #region Overrides
        public override TValue First()
        {
            var entry = this._enumerative.First();

            if (entry is KeyValuePair<TKey, TValue> kvp)
            {
                return kvp.Value;
            }
            else if (entry is RedBlackNode<TKey, TValue> rbn)
            {
                return rbn.Value;
            }
            else if (entry is System.Collections.Generic.KeyValuePair<TKey, TValue> de)
            {
                return de.Value;
            }

            throw new InvalidCastException($"Unable to cast object of type '{entry.GetType().FullName}' to type '{typeof(KeyValuePair).FullName}'.");
        }
        public override ISeq<TValue> Next() => Create(this._enumerative.Next());
        public override IStack<TValue> Pop() => throw new NotImplementedException();
        
        public override System.Collections.Generic.IEnumerator<TValue> GetEnumerator()
        {
            if (this._enumerable is null)
            {
                return base.GetEnumerator();
            }

            if (this._enumerable is IMapEnumerable<TKey, TValue> m)
            {
                return m.GetValueEnumerator();
            }

            return null;
        }
        #endregion
    }
}

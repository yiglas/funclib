using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    sealed class KeySeq :
        ASeq,
        System.Collections.IEnumerable
    {
        readonly ISeq _enumerative;
        readonly System.Collections.IEnumerable _enumerable;

        KeySeq(ISeq enumerative, System.Collections.IEnumerable enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static KeySeq Create(ISeq enumerative) =>
            enumerative == null
                ? null
                : new KeySeq(enumerative, null);

        public static KeySeq Create(IMap map)
        {
            var enumerative = map?.Seq();
            if (enumerative == null) return null;

            return new KeySeq(enumerative, map);
        }
        #endregion

        #region Overrides
        public override object First()
        {
            var entry = this._enumerative.First();

            if (entry is KeyValuePair kvp) return kvp.Key;
            else if (entry is RedBlackNode rbn) return rbn.Key;
            else if (entry is System.Collections.DictionaryEntry de)
                return de.Key;

            throw new InvalidCastException($"Unable to cast object of type '{entry.GetType().FullName}' to type '{typeof(KeyValuePair).FullName}'.");
        }
        public override ISeq Next() => Create(this._enumerative.Next());
        public override IStack Pop() => throw new NotImplementedException();
        public override System.Collections.IEnumerator GetEnumerator()
        {
            if (this._enumerable == null) return base.GetEnumerator();

            if (this._enumerable is IMapEnumerable m)
                return m.GetKeyEnumerator();

            return null;
        }
        #endregion
    }
}

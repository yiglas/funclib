using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    sealed class ValueSeq :
        ASeq,
        System.Collections.IEnumerable
    {
        readonly ISeq _enumerative;
        readonly System.Collections.IEnumerable _enumerable;

        ValueSeq(ISeq enumerative, System.Collections.IEnumerable enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static ValueSeq Create(ISeq enumerative) =>
            enumerative == null
                ? null
                : new ValueSeq(enumerative, null);

        public static ValueSeq Create(IMap map)
        {
            var enumerative = map?.Seq();
            if (enumerative == null) return null;

            return new ValueSeq(enumerative, map);
        }
        #endregion

        #region Overrides
        public override object First()
        {
            var entry = this._enumerative.First();

            if (entry is KeyValuePair kvp) return kvp.Value;
            if (entry is RedBlackNode rbn) return rbn.Value;
            else if (entry is System.Collections.DictionaryEntry de)
                return de.Value;

            throw new InvalidCastException($"Unable to cast object of type '{entry.GetType().FullName}' to type '{typeof(KeyValuePair).FullName}'.");
        }
        public override ISeq Next() => Create(this._enumerative.Next());
        public override System.Collections.IEnumerator GetEnumerator()
        {
            if (this._enumerable == null) return base.GetEnumerator();

            if (this._enumerable is IMapEnumerable m)
                return m.GetValueEnumerator();

            return null;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

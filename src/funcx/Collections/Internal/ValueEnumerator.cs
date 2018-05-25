using System;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class ValueEnumerative :
        Enumerative,
        System.Collections.IEnumerable
    {
        readonly IEnumerative _enumerative;
        readonly System.Collections.IEnumerable _enumerable;

        ValueEnumerative(IEnumerative enumerative, System.Collections.IEnumerable enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static ValueEnumerative Create(IEnumerative enumerative) =>
            enumerative == null
                ? null
                : new ValueEnumerative(enumerative, null);

        public static ValueEnumerative Create(IMap map)
        {
            var enumerative = map?.Enumerate();
            if (enumerative == null) return null;

            return new ValueEnumerative(enumerative, map);
        }
        #endregion

        #region Overrides
        public override object First()
        {
            var entry = this._enumerative.First();

            if (entry is System.Collections.Generic.KeyValuePair<object, object> kvp) return kvp.Value;
            else if (entry is System.Collections.DictionaryEntry de)
                return de.Value;

            throw new InvalidCastException($"Cannot convert entry to {nameof(System.Collections.Generic.KeyValuePair<object, object>)} or {nameof(System.Collections.DictionaryEntry)}");
        }
        public override IEnumerative Next() => Create(this._enumerative.Next());
        public override IStack Pop() => throw new NotImplementedException();
        public override System.Collections.Generic.IEnumerator<object> GetEnumerator()
        {
            if (this._enumerable == null) return base.GetEnumerator();

            if (this._enumerable is IMapEnumerable m)
                return (System.Collections.Generic.IEnumerator<object>)m.GetValueEnumerator();

            return null;
        }
        #endregion

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        System.Collections.Generic.IEnumerable<object> Iterator(System.Collections.IEnumerable enumerable)
        {
            foreach (var item in enumerable)
                yield return ((System.Collections.Generic.KeyValuePair<object, object>)item).Value;
        }
    }
}

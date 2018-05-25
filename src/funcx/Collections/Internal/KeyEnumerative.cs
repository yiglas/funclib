using System;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class KeyEnumerative :
        Enumerative,
        System.Collections.IEnumerable
    {
        readonly IEnumerative _enumerative;
        readonly System.Collections.IEnumerable _enumerable;

        KeyEnumerative(IEnumerative enumerative, System.Collections.IEnumerable enumerable)
        {
            this._enumerable = enumerable;
            this._enumerative = enumerative;
        }

        #region Creates
        public static KeyEnumerative Create(IEnumerative enumerative) =>
            enumerative == null
                ? null
                : new KeyEnumerative(enumerative, null);

        public static KeyEnumerative Create(IMap map)
        {
            var enumerative = map?.Enumerate();
            if (enumerative == null) return null;

            return new KeyEnumerative(enumerative, map);
        }
        #endregion

        #region Overrides
        public override object First()
        {
            var entry = this._enumerative.First();

            if (entry is System.Collections.Generic.KeyValuePair<object, object> kvp) return kvp.Key;
            else if (entry is System.Collections.DictionaryEntry de)
                return de.Key;

            throw new InvalidCastException($"Cannot convert entry to {nameof(System.Collections.Generic.KeyValuePair<object, object>)} or {nameof(System.Collections.DictionaryEntry)}");
        }
        public override IEnumerative Next() => Create(this._enumerative.Next());
        public override IStack Pop() => throw new NotImplementedException();
        public override System.Collections.Generic.IEnumerator<object> GetEnumerator()
        {
            if (this._enumerable == null) return base.GetEnumerator();

            if (this._enumerable is IMapEnumerable m)
                return (System.Collections.Generic.IEnumerator<object>)m.GetKeyEnumerator();

            return null;
        }
        #endregion

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        System.Collections.Generic.IEnumerable<object> Iterator(System.Collections.IEnumerable enumerable)
        {
            foreach (var item in enumerable)
                yield return ((System.Collections.Generic.KeyValuePair<object, object>)item).Key;
        }
    }
}

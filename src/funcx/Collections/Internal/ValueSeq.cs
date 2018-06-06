﻿using System;
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

            if (entry is System.Collections.Generic.KeyValuePair<object, object> kvp) return kvp.Value;
            else if (entry is System.Collections.DictionaryEntry de)
                return de.Value;

            throw new InvalidCastException($"Cannot convert entry to {nameof(System.Collections.Generic.KeyValuePair<object, object>)} or {nameof(System.Collections.DictionaryEntry)}");
        }
        public override ISeq Next() => Create(this._enumerative.Next());
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
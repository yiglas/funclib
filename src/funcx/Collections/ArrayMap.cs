using funcx.Collections.Internal;
using System;
using System.Collections;
using System.Text;

namespace funcx.Collections
{
    public class ArrayMap :
        Map
    {
        public static readonly ArrayMap EMPTY = new ArrayMap();

        object[] _array;

        ArrayMap() : this(new object[] { }) { }
        ArrayMap(object[] init)
        {
            this._array = init;
        }

        #region Creates
        public static ArrayMap Create(object[] init) => new ArrayMap(init);
        #endregion

        #region Overrides
        public override int Count => this._array.Length / 2;
        public override IMap Assoc(object key, object val)
        {
            int i = IndexOf(key);
            object[] newArray;

            if (i >= 0)
            {
                // key exists, same size replacement
                if (this._array[i + 1] == val) return this;

                newArray = this._array.Clone() as object[];
                newArray[i + 1] = val;
            }
            else
            {
                if (this._array.Length > Constants.HASH_TABLE_THRESHOLD)
                    return CreateHashMap(this._array, key, val);

                newArray = new object[this._array.Length + 2];
                if (this._array.Length > 0)
                    Array.Copy(this._array, 0, newArray, 0, this._array.Length);

                newArray[newArray.Length - 2] = key;
                newArray[newArray.Length - 1] = val;
            }

            return Create(newArray);
        }
        public override bool ContainsKey(object key) => IndexOf(key) >= 0;
        public override ICollection Empty() => EMPTY;
        public override System.Collections.Generic.KeyValuePair<object, object>? Get(object key)
        {
            var i = IndexOf(key);
            if (i >= 0)
            {
                return new System.Collections.Generic.KeyValuePair<object, object>(this._array[i], this._array[i + 1]);
            }

            return null;
        }
        public override object GetValue(object key) => GetValue(key, null);
        public override object GetValue(object key, object notFound)
        {
            int i = IndexOf(key);
            return i >= 0 ? this._array[i + 1] : notFound;
        }
        public override IMap Without(object key)
        {
            int i = IndexOf(key);
            if (i >= 0)
            {
                int length = this._array.Length - 2;
                if (length == 0) return EMPTY;

                object[] newArray = new object[length];
                Array.Copy(this._array, 0, newArray, 0, i);
                Array.Copy(this._array, i + 2, newArray, i, length - i);

                return Create(newArray);
            }

            return this;
        }
        public override ITransientCollection ToTransient() => new TransientArrayMap(this._array);
        public override IEnumerative Enumerate() => this._array.Length > 0 ? new ArrayEnumerative(this._array, 0) : null;
        public override IEnumerator GetKeyEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
                yield return this._array[i];
        }
        public override IEnumerator GetValueEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
                yield return this._array[i + 1];
        }
        #endregion

        int IndexOf(object key)
        {
            var pred = predicate(key);

            for (int i = 0; i < this._array.Length; i += 2)
                if (pred(key, this._array[i]))
                    return i;

            return -1;

            Func<object, object, bool> predicate(object k) =>
                k == null
                    ? (k1, k2) => k2 == null
                    : Number.IsNumber(k) ? new Func<object, object, bool>((k1, k2) => Number.IsEqual(k1, k2))
                    : (object k1, object k2) => k1.Equals(k2);
        }
        IMap CreateHashMap(object[] init, object key, object val) => HashMap.Create(init).Assoc(key, val);
    }
}

using funclib.Collections.Internal;
using funclib.Components.Core;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Collections
{
    public class ArrayMap :
        AMap,
        IReduceKV
    {
        public static readonly ArrayMap EMPTY = new ArrayMap();

        object[] _array;

        ArrayMap() : this(new object[] { }) { }
        internal ArrayMap(object[] init)
        {
            this._array = init;
        }

        #region Creates
        public static ArrayMap Create(params object[] init)
        {
            if ((init.Length & 1) == 1)
                throw new ArgumentException($"No value supplied for key: {init[init.Length - 1]}");

            int n = 0;
            for (int i = 0; i < init.Length; i+= 2)
            {
                bool duplicateKey = false;
                for (int j = 0; j < i; j += 2)
                {
                    if ((bool)isEqualTo(init[i], init[j]))
                    {
                        duplicateKey = true;
                        break;
                    }
                }
                if (!duplicateKey) n += 2;
            }

            if (n < init.Length)
            {
                var nodups = new object[n];
                int m = 0;
                for (int i = 0; i < init.Length; i += 2)
                {
                    bool duplicateKey = false;
                    for (int j = 0; j < m; j += 2)
                    {
                        if ((bool)isEqualTo(init[i], nodups[j]))
                        {
                            duplicateKey = true;
                            break;
                        }
                    }

                    if (!duplicateKey)
                    {
                        int j;
                        for (j = init.Length -2; j >= i; j -= 2)
                        {
                            if ((bool)isEqualTo(init[i], init[j]))
                            {
                                break;
                            }
                        }
                        nodups[m] = init[i];
                        nodups[m + 1] = init[j + 1];
                        m += 2;
                    }
                }

                if (m != n)
                    throw new ArgumentException($"Internal error: m = {m}");

                init = nodups;
            }

            return new ArrayMap(init);
        }
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
                    System.Array.Copy(this._array, 0, newArray, 0, this._array.Length);

                newArray[newArray.Length - 2] = key;
                newArray[newArray.Length - 1] = val;
            }

            return Create(newArray);
        }
        public override bool ContainsKey(object key) => IndexOf(key) >= 0;
        public override ICollection Empty() => EMPTY;
        public override IKeyValuePair Get(object key)
        {
            var i = IndexOf(key);
            if (i >= 0)
            {
                return new KeyValuePair(this._array[i], this._array[i + 1]);
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
                System.Array.Copy(this._array, 0, newArray, 0, i);
                System.Array.Copy(this._array, i + 2, newArray, i, length - i);

                return Create(newArray);
            }

            return this;
        }
        public override ITransientCollection ToTransient() => new TransientArrayMap(this._array);
        public override ISeq Seq() => this._array.Length > 0 ?  new ArrayMapSeq(this._array, 0) : null;
        public override System.Collections.IEnumerator GetKeyEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
                yield return this._array[i];
        }
        public override System.Collections.IEnumerator GetValueEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
                yield return this._array[i + 1];
        }
        #endregion


        public object ReduceKV(object f, object init)
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                init = invoke(f, init, this._array[i], this._array[i + 1]);
                if (init is Reduced r)
                    return r.Deref();
            }
            return init;
        }

        int IndexOf(object key)
        {
            var pred = predicate(key);

            for (int i = 0; i < this._array.Length; i += 2)
                if (pred(key, this._array[i]))
                    return i;

            return -1;

            Func<object, object, bool> predicate(object k) =>
                k is null
                    ? (k1, k2) => k2 is null
                    : Numbers.IsNumber(k) ? new Func<object, object, bool>((k1, k2) => Numbers.IsEqual(k1, k2))
                    : (object k1, object k2) => k1.Equals(k2);
        }
        IMap CreateHashMap(object[] init, object key, object val) => HashMap.Create(init).Assoc(key, val);
    }
}

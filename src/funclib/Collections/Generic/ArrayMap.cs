using System;
using System.Collections.Generic;

namespace funclib.Collections.Generic
{
    public class ArrayMap<TKey, TValue> :
        AMap<TKey, TValue>,
        IReduceKV<TKey, TValue>
    {
        public static readonly ArrayMap<TKey, TValue> EMPTY = new ArrayMap<TKey, TValue>();

        UnionType<TKey, TValue>[] _array;

        ArrayMap() :
            this(new UnionType<TKey, TValue>[0])
        { }

        internal ArrayMap(UnionType<TKey, TValue>[] init)
        {
            this._array = init;
        }

        #region Creates
        public static ArrayMap<TKey, TValue> Create(params UnionType<TKey, TValue>[] init)
        {
            if ((init.Length & 1) == 1)
            {
                throw new ArgumentException($"No value supplied for key: {init[init.Length - 1]}");
            }

            int n = 0;
            for (int i = 0; i < init.Length; i+= 2)
            {
                bool duplicateKey = false;

                for (int j = 0; j < i; j += 2)
                {
                    if (funclib.Generic.Core.IsEqualTo(init[i], init[j]))
                    {
                        duplicateKey = true;
                        break;
                    }
                }

                if (!duplicateKey)
                {
                    n += 2;
                }
            }

            if (n < init.Length)
            {
                var nodups = new UnionType<TKey, TValue>[n];
                int m = 0;
                for (int i = 0; i < init.Length; i += 2)
                {
                    bool duplicateKey = false;
                    for (int j = 0; j < m; j += 2)
                    {
                        if (funclib.Generic.Core.IsEqualTo(init[i], nodups[j]))
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
                            if (funclib.Generic.Core.IsEqualTo(init[i], init[j]))
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
                {
                    throw new ArgumentException($"Internal error: m = {m}");
                }

                init = nodups;
            }

            return new ArrayMap<TKey, TValue>(init);
        }
        #endregion

        #region  Overrides
        public override int Count => this._array.Length / 2;
        public override IMap<TKey, TValue> Assoc(TKey key, TValue val)
        {
            int i = IndexOf(key);
            UnionType<TKey, TValue>[] newArray;

            if (i >= 0)
            {
                // key exists, same size replacement
                if (this._array[i + 1] == val)
                {
                    return this;
                }

                newArray = this._array.Clone() as UnionType<TKey, TValue>[];
                newArray[i + 1] = val;
            }
            else
            {
                if (this._array.Length > Constants.HASH_TABLE_THRESHOLD)
                {
                    return CreateHashMap(this._array, key, val);
                }

                newArray = new UnionType<TKey, TValue>[this._array.Length + 2];

                if (this._array.Length > 0)
                {
                    System.Array.Copy(this._array, 0, newArray, 0, this._array.Length);
                }

                newArray[newArray.Length - 2] = key;
                newArray[newArray.Length - 1] = val;
            }

            return Create(newArray);
        }
        public override bool ContainsKey(TKey key) => IndexOf(key) >= 0;
        public override ICollection<IKeyValuePair<TKey, TValue>> Empty() => EMPTY;
        public override IKeyValuePair<TKey, TValue> Get(TKey key)
        {
            var i = IndexOf(key);
            if (i >= 0)
            {
                return KeyValuePair<TKey, TValue>.Create(this._array[i], this._array[i + 1]);
            }

            return null;
        }
        public override TValue GetValue(TKey key) => GetValue(key, default);
        public override TValue GetValue(TKey key, TValue notFound)
        {
            var i = IndexOf(key);
            if (i >= 0)
            {
                return this._array[i + 1];
            }

            return notFound;
        }
        public override IMap<TKey, TValue> Without(TKey key)
        {
            int i = IndexOf(key);
            if (i >= 0)
            {
                int length = this._array.Length - 2;
                if (length == 0)
                {
                    return EMPTY;
                }

                var newArray = new UnionType<TKey, TValue>[length];

                System.Array.Copy(this._array, 0, newArray, 0, i);
                System.Array.Copy(this._array, i + 2, newArray, i, length - i);

                return Create(newArray);
            }

            return this;
        }
        public override ISeq<IKeyValuePair<TKey, TValue>> Seq()
        {
            throw new System.NotImplementedException();
        }
        public override ITransientCollection<IKeyValuePair<TKey, TValue>> ToTransient()
        {
            throw new System.NotImplementedException();
        }
        public override IEnumerator<TKey> GetKeyEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                yield return this._array[i];
            }
        }
        public override IEnumerator<TValue> GetValueEnumerator()
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                yield return this._array[i + 1];
            }
        }
        #endregion

        public TResult ReduceKV<TResult>(System.Func<TResult, TKey, TValue, TResult> f, TResult init)
        {
            throw new System.NotImplementedException();
        }

        int IndexOf(TKey key)
        {
            var pred = predicate(key);

            for (int i = 0; i < this._array.Length; i += 2)
            {
                if (pred(key, this._array[i]))
                {
                    return i;
                }
            }

            return -1;

            Func<TKey, TKey, bool> predicate(TKey k)
            {
                if (k is null)
                {
                    return (k1, k2) => k2 is null;
                }
                else if (Numbers.IsNumber(k))
                {
                    return (k1, k2) => Numbers.IsEqual(k1, k2);
                }

                return (k1, k2) => k1.Equals(k2);
            }
        }
        IMap<TKey, TValue> CreateHashMap(UnionType<TKey, TValue>[] init, TKey key, TValue val)
        {
            return HashMap<TKey, TValue>.Create(init).Assoc(key, val);
        }
    }
}
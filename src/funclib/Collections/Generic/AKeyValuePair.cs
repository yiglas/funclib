using System;
using System.Linq;

namespace funclib.Collections.Generic
{
    public abstract class AKeyValuePair<TKey, TValue> :
        AVector<UnionType<TKey, TValue>>,
        IKeyValuePair<TKey, TValue>
    {
        #region Abstract Methods
        public abstract TKey Key { get; }
        public abstract TValue Value { get; }
        #endregion

        #region Overrides
        public override int Count => 2;
        public override UnionType<TKey, TValue> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Key;
                    case 1: return Value;
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set => throw new NotImplementedException();
        }

        public override IVector<UnionType<TKey, TValue>> Assoc(int i, UnionType<TKey, TValue> val) => ToVector(Key, Value).Assoc(i, val);
        public override IVector<UnionType<TKey, TValue>> Cons(UnionType<TKey, TValue> o) => ToVector(Key, Value).Cons(o);
        public override bool ContainsKey(int key) => ToVector(Key, Value).ContainsKey(key);
        public override IKeyValuePair<int, UnionType<TKey, TValue>> Get(int key) => ToVector(Key, Value).Get(key);
        public override UnionType<TKey, TValue> GetValue(int key) => ToVector(Key, Value).GetValue(key);
        public override UnionType<TKey, TValue> GetValue(int key, UnionType<TKey, TValue> notFound) => ToVector(Key, Value).GetValue(key, notFound);
        public override ISeq<UnionType<TKey, TValue>> Seq() => ToVector(Key, Value).Seq();
        public override IVector<UnionType<TKey, TValue>> Empty() => null;
        public override UnionType<TKey, TValue> Peek() => Value;
        public override IStack<UnionType<TKey, TValue>> Pop() => ToVector(Key);
        #endregion

        IVector<UnionType<TKey, TValue>> ToVector(params UnionType<TKey, TValue>[] items)
        {
            if (items.Length <= 32)
            {
                throw new NotImplementedException("TODO"); // return new Vector<UnionType<TKey, TValue>>(2, 5, Vector<UnionType<TKey, TValue>>.EmptyNode, items.Select(x => (UnionType<TKey, TValue>)x).ToArray());
            }

            return Vector<UnionType<TKey, TValue>>.Create(items);
        }
    }
}

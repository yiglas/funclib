using System;
using System.Linq;
using funclib.Collections.Generic.Internal;

namespace funclib.Collections.Generic
{
    public abstract class AKeyValuePair<TKey, TValue> :
        AVector<UnionType<TKey, TValue, Nil>>,
        IKeyValuePair<TKey, TValue>
    {
        #region Abstract Methods
        public abstract UnionType<TKey, Nil> Key { get; }
        public abstract UnionType<TValue, Nil> Value { get; }
        #endregion

        #region Overrides
        public override int Count => 2;
        public override UnionType<UnionType<TKey, TValue, Nil>, Nil> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return UnionType<UnionType<TKey, TValue, Nil>, Nil>.Create(Key);
                    case 1: return UnionType<UnionType<TKey, TValue, Nil>, Nil>.Create(Value);
                }

                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set => throw new NotImplementedException();
        }
        public override IVector<UnionType<UnionType<TKey, TValue, Nil>, Nil>> Assoc(int i, UnionType<TKey, TValue, Nil> val) => ToVector(Key, Value).Assoc(i, UnionType<UnionType<TKey, TValue, Nil>, Nil>.Create(val));
        #endregion

        IVector<UnionType<UnionType<TKey, TValue, Nil>, Nil>> ToVector(params UnionType<UnionType<TKey, Nil>, UnionType<TValue, Nil>>[] items)
        {
            return null;
        }
    }
}

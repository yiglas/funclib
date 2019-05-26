using System;

namespace funclib.Collections.Generic
{
    public abstract class AKeyValuePair<TKey, TValue> :
        AVector<IKeyValuePair<TKey, TValue>>,
        IKeyValuePair<TKey, TValue>
    {
        #region Abstract Methods
        public abstract TKey Key { get; }
        public abstract TValue Value { get; }
        #endregion

        #region Overrides
        public override int Count => 2;
        public override IKeyValuePair<TKey, TValue> this[int index]
        {
            get
            {
                return this;
            }
            set => throw new NotImplementedException();
        }

        public override IVector<IKeyValuePair<TKey, TValue>> Assoc
        #endregion

        IVector<IKeyValuePair<TKey, TValue>> ToVector(TKey key, TValue value)
        {
            
        }
    }
}

using System;

namespace funclib.Collections.Generic
{
    public class KeyValuePair<TKey, TValue> :
        AKeyValuePair<TKey, TValue>
    {
        public override TKey Key { get; }
        public override TValue Value { get; }

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        #region Creates
        public static KeyValuePair<TKey, TValue> Create(TKey key, TValue value) => new KeyValuePair<TKey, TValue>(key, value);
        #endregion

        #region Overrides
        public override ITransientCollection<UnionType<TKey, TValue>> ToTransient() => throw new NotImplementedException();
        #endregion
    }
}

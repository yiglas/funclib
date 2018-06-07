using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections
{
    public class KeyValuePair :
        AKeyValuePair
    {
        public override object Key { get; }
        public override object Value { get; }

        public KeyValuePair(object key, object value)
        {
            Key = key;
            Value = value;
        }

        #region Creates
        public static KeyValuePair Create(object key, object value) => new KeyValuePair(key, value);
        #endregion

        #region Overrides
        public override ITransientCollection ToTransient() => throw new NotImplementedException();
        #endregion
    }
}

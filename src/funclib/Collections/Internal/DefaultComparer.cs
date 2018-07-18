using System;
using System.Runtime.Serialization;
using System.Text;

namespace funclib.Collections.Internal
{
    [Serializable]
    class DefaultComparer :
        System.Collections.IComparer,
        ISerializable
    {
        public static readonly System.Collections.IComparer Instance = new DefaultComparer();

        public int Compare(object x, object y) => (int)new funclib.Components.Core.Compare().Invoke(x, y);
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(DefaultComparerSerialization));
        }

        [Serializable]
        class DefaultComparerSerialization :
            IObjectReference
        {
            public object GetRealObject(StreamingContext context) => DefaultComparer.Instance;
        }
    }
}

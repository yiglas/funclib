using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    [Serializable]
    class DefaultComparer :
        IComparer,
        ISerializable
    {
        public static readonly IComparer Instance = new DefaultComparer();

        public int Compare(object x, object y) => new Core.Compare().Invoke(x, y);
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

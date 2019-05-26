using funclib.Collections.Generic;
using System;
using System.Threading;

namespace funclib.Collections.Internal.Generic
{
    [Serializable]
    sealed class VectorNode<T>
    {

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public AtomicReference<Thread> Edit => this._edit;
        public T[] Array { get; }


        public VectorNode(AtomicReference<Thread> edit) : this(edit, new T[32]) { }
        public VectorNode(AtomicReference<Thread> edit, T[] array)
        {
            this._edit = edit;
            Array = array;
        }
    }
}

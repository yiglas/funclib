using funclib.Collections.Generic;
using funclib.Collections.Generic.Internal;
using System;
using System.Linq;
using System.Threading;

namespace funclib.Collections.Internal.Generic
{
    [Serializable]
    sealed class VectorNode<T>
    {

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public AtomicReference<Thread> Edit => this._edit;
        public UnionType<T, VectorNode<T>>[] Array { get; }


        public VectorNode(AtomicReference<Thread> edit) : this(edit, new T[32]) { }
        public VectorNode(AtomicReference<Thread> edit, T[] array)
        {
            this._edit = edit;
            Array = array.Select(x => new UnionType<T, VectorNode<T>>(x)).ToArray()
        }
        public VectorNode(AtomicReference<Thread> edit, VectorNode<T> array)
        {
            this._edit = edit;
            Array = new UnionType<T[], VectorNode<T>>(array);
        }
    }
}

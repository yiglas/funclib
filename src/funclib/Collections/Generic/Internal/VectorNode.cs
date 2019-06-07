using funclib.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

namespace funclib.Collections.Generic.Internal
{
    [Serializable]
    public sealed class VectorNode<T>
    {

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public AtomicReference<Thread> Edit => this._edit;
        public UnionType<T, VectorNode<T>>[] Array { get; }


        public VectorNode(AtomicReference<Thread> edit) : this(edit, new UnionType<T, VectorNode<T>>[32]) { }
        public VectorNode(AtomicReference<Thread> edit, UnionType<T, VectorNode<T>>[] array)
        {
            this._edit = edit;
            this.Array = array;
        }
    }
}

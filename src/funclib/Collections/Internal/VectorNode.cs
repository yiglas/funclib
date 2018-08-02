using funclib.Collections.Generic;
using System;
using System.Text;
using System.Threading;

namespace funclib.Collections.Internal
{
    [Serializable]
    sealed class VectorNode
    {

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        public AtomicReference<Thread> Edit => this._edit;
        public object[] Array { get; }


        public VectorNode(AtomicReference<Thread> edit) : this(edit, new object[32]) { }
        public VectorNode(AtomicReference<Thread> edit, object[] array)
        {
            this._edit = edit;
            Array = array;
        }
    }
}

using FunctionalLibrary.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunctionalLibrary.Collections.Internal
{
    interface INode
    {
        INode Assoc(int shift, int hash, object key, object val, Box addedLeaf);
        INode Assoc(AtomicReference<Thread> edit, int shift, int hash, object key, object val, Box addedLeaf);
        INode Without(int shift, int hash, object key);
        INode Without(AtomicReference<Thread> edit, int shift, int hash, object key, Box removedLeaf);
        KeyValuePair<object, object>? Get(int shift, int hash, object key);
        object Get(int shift, int hash, object key, object notFound);
        ISeq GetNodeEnumerative();
        IEnumerator GetEnumerator(Func<object, object, object> d);
    }
}

using FunctionalLibrary.Core;
using System;
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
        System.Collections.Generic.KeyValuePair<object, object>? Get(int shift, int hash, object key);
        object Get(int shift, int hash, object key, object notFound);
        ISeq GetNodeEnumerative();
        System.Collections.IEnumerator GetEnumerator(Func<object, object, object> d);
        object Reduce(IFunction<object, object, object, object> f, object init);
    }
}

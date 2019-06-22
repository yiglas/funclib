using System;
using System.Threading;

namespace funclib.Collections.Generic.Internal
{
    interface INode<TKey, TValue>
    {
        INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(int shift, int hash, UnionType<TKey, Nil> key, UnionType<TValue, Nil> val, Box<object> addedLeaf);
        INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Assoc(AtomicReference<Thread> edit, int shift, int hash, UnionType<TKey, Nil> key, UnionType<TValue, Nil> val, Box<object> addedLeaf);
        INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Without(int shift, int hash, UnionType<TKey, Nil> key);
        INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Without(AtomicReference<Thread> edit, int shift, int hash, UnionType<TKey, Nil> key, Box<object> removedLeaf);
        IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>> Get(int shift, int hash, UnionType<TKey, Nil> key);
        UnionType<UnionType<TValue, Nil>, Nil> Get(int shift, int hash, UnionType<TKey, Nil> key, UnionType<TValue, Nil> notFound);
        ISeq<IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>>> GetNodeEnumerative();
        System.Collections.Generic.IEnumerator<IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>>> GetEnumerator(Func<UnionType<TKey, Nil>, UnionType<UnionType<TValue, Nil>, INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>>>, IKeyValuePair<UnionType<TKey, Nil>, UnionType<TValue, Nil>>> d);
        TAccumulate Reduce<TAccumulate>(Func<TAccumulate, UnionType<UnionType<TKey, Nil>, UnionType<TValue, Nil>, INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>>>, UnionType<UnionType<TKey, Nil>, UnionType<TValue, Nil>, INode<UnionType<TKey, Nil>, UnionType<TValue, Nil>>>, TAccumulate> f, TAccumulate init);
    }
}

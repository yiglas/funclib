using System;

namespace funclib.Collections.Generic.Internal
{
    class ArrayNodeSeq<TKey, TValue> :
        ASeq<IKeyValuePair<TKey, TValue>>
    {
        readonly INode<TKey, TValue>[] _nodes;
        readonly int _i;
        readonly ISeq<IKeyValuePair<TKey, TValue>> _e;

        ArrayNodeSeq(INode<TKey, TValue>[] nodes, int i, ISeq<IKeyValuePair<TKey, TValue>> e)
        {
            this._nodes = nodes;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static ISeq<IKeyValuePair<TKey, TValue>> Create(INode<TKey, TValue>[] nodes) => Create(nodes, 0, null);

        public static ISeq<IKeyValuePair<TKey, TValue>> Create(INode<TKey, TValue>[] nodes, int i, ISeq<IKeyValuePair<TKey, TValue>> e)
        {
            if (e != null)
            {
                return new ArrayNodeSeq<TKey, TValue>(nodes, i, e);
            }

            for(int j = i; j < nodes.Length; j++)
            {
                if (nodes[j] != null)
                {
                    var ns = nodes[j].GetNodeEnumerative();
                    if (ns != null)
                    {
                        return new ArrayNodeSeq<TKey, TValue>(nodes, j + 1, ns);
                    }
                }
            }

            return null;
        }
        #endregion

        #region Overrides
        public override IKeyValuePair<TKey, TValue> First() => this._e.First();
        public override ISeq<IKeyValuePair<TKey, TValue>> Next() => Create(this._nodes, this._i, this._e.Next());
        public override IStack<IKeyValuePair<TKey, TValue>> Pop() => throw new NotImplementedException();
        #endregion
    }
}
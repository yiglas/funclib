using System;
using System.Text;

namespace funclib.Collections.Internal
{
    class ArrayNodeSeq :
        ASeq
    {
        readonly INode[] _nodes;
        readonly int _i;
        readonly ISeq _e;

        ArrayNodeSeq(INode[] nodes, int i, ISeq e)
        {
            this._nodes = nodes;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static ISeq Create(INode[] nodes) => Create(nodes, 0, null);

        public static ISeq Create(INode[] nodes, int i, ISeq e)
        {
            if (e != null) return new ArrayNodeSeq(nodes, i, e);
            
            for(int j = i; j < nodes.Length; j++)
            {
                if (nodes[j] != null)
                {
                    var ns = nodes[j].GetNodeEnumerative();
                    if (ns != null)
                        return new ArrayNodeSeq(nodes, j + 1, ns);
                }
            }

            return null;
        }

        #endregion

        #region Overrides
        public override object First() => this._e.First();
        public override ISeq Next() => Create(this._nodes, this._i, this._e.Next());
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

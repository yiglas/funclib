using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    class ArrayNodeEnumerative :
        Enumerative
    {
        readonly INode[] _nodes;
        readonly int _i;
        readonly IEnumerative _e;

        ArrayNodeEnumerative(INode[] nodes, int i, IEnumerative e)
        {
            this._nodes = nodes;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static IEnumerative Create(INode[] nodes) => Create(nodes, 0, null);

        public static IEnumerative Create(INode[] nodes, int i, IEnumerative e)
        {
            if (e != null) return new ArrayNodeEnumerative(nodes, i, e);
            
            for(int j = i; j < nodes.Length; j++)
            {
                if (nodes[j] != null)
                {
                    var ns = nodes[j].GetNodeEnumerative();
                    if (ns != null)
                        return new ArrayNodeEnumerative(nodes, j + 1, ns);
                }
            }

            return null;
        }

        #endregion

        #region Overrides
        public override object First() => this._e.First();
        public override IEnumerative Next() => Create(this._nodes, this._i, this._e.Next());
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

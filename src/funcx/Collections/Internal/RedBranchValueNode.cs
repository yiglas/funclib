using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class RedBranchValueNode :
        RedBranchNode
    {
        readonly object _val;

        public RedBranchValueNode(object key, object val, RedBlackNode left, RedBlackNode right) :
            base(key, left, right)
        {
            this._val = val;
        }

        public override object Value => this._val;

        protected internal override RedBlackNode Blacken() => new BlackBranchValueNode(this._key, this._val, this._left, this._right);
    }
}

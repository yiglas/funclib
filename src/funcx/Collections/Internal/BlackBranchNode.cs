using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class BlackBranchNode :
        BlackNode
    {
        protected readonly RedBlackNode _left;
        protected readonly RedBlackNode _right;

        public BlackBranchNode(object key, RedBlackNode left, RedBlackNode right) :
            base(key)
        {
            this._left = left;
            this._right = right;
        }


        protected internal override RedBlackNode Left => this._left;
        protected internal override RedBlackNode Right => this._right;

        protected internal override RedBlackNode Redden() => new RedBranchNode(this._key, this._left, this._right);
    }
}

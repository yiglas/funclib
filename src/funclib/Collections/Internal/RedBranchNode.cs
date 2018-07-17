using System;
using System.Text;

namespace funclib.Collections.Internal
{
    class RedBranchNode :
        RedNode
    {
        protected readonly RedBlackNode _left;
        protected readonly RedBlackNode _right;

        public RedBranchNode(object key, RedBlackNode left, RedBlackNode right) :
            base(key)
        {
            this._left = left;
            this._right = right;
        }

        protected internal override RedBlackNode Left => this._left;
        protected internal override RedBlackNode Right => this._right;

        protected internal override RedBlackNode BalanceLeft(RedBlackNode parent)
        {
            if (this._left is RedNode)
                return SortedMap.MakeRed(this._key, Value, 
                    this._left.Blacken(), 
                    SortedMap.MakeBlack(parent.Key, parent.Value, this._right, parent.Right));
            else if (this._right is RedNode)
                return SortedMap.MakeRed(this._right.Key, this._right.Value, 
                    SortedMap.MakeBlack(this._key, Value, this._left, this._right.Left),
                    SortedMap.MakeBlack(parent.Key, parent.Value, this._right.Right, parent.Right));
            else
                return base.BalanceLeft(parent);
        }

        protected internal override RedBlackNode BalanceRight(RedBlackNode parent)
        {
            if (this._right is RedNode)
                return SortedMap.MakeRed(this._key, Value, 
                    SortedMap.MakeBlack(parent.Key, parent.Value, parent.Left, this._left), 
                    this._right.Blacken());
            else if (this._left is RedNode)
                return SortedMap.MakeRed(this._left.Key, this._left.Value, 
                    SortedMap.MakeBlack(parent.Key, parent.Value, parent.Left, this._left.Left),
                    SortedMap.MakeBlack(this._key, Value, this._left.Right, this._right));
            else
                return base.BalanceRight(parent);
        }

        protected internal override RedBlackNode Blacken() => new BlackBranchNode(this._key, this._left, this._right);
    }
}

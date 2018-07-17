using System;
using System.Text;

namespace funclib.Collections.Internal
{
    class BlackNode :
        RedBlackNode
    {
        public BlackNode(object key) : base(key) { }

        public override object Value => null;

        protected internal override RedBlackNode AddLeft(RedBlackNode insert) => insert.BalanceLeft(this);
        protected internal override RedBlackNode AddRight(RedBlackNode insert) => insert.BalanceRight(this);
        protected internal override RedBlackNode Blacken() => this;
        protected internal override RedBlackNode Redden() => new RedNode(this._key);
        protected internal override RedBlackNode RemoveLeft(RedBlackNode delete) => SortedMap.BalanceLeftDelete(this._key, Value, delete, Right);
        protected internal override RedBlackNode RemoveRight(RedBlackNode delete) => SortedMap.BalanceRightDelete(this._key, Value, Left, delete);
        protected internal override RedBlackNode Replace(object key, object val, RedBlackNode left, RedBlackNode right) => SortedMap.MakeBlack(key, val, left, right);
    }
}

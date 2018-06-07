using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class RedNode :
        RedBlackNode
    {
        public RedNode(object key) : base(key) { }

        public override object Value => null;

        protected internal override RedBlackNode AddLeft(RedBlackNode insert) => SortedMap.MakeRed(this._key, Value, insert, Right);
        protected internal override RedBlackNode AddRight(RedBlackNode insert) => SortedMap.MakeRed(this._key, Value, Left, insert);
        protected internal override RedBlackNode RemoveLeft(RedBlackNode delete) => SortedMap.MakeRed(this._key, Value, delete, Right);
        protected internal override RedBlackNode RemoveRight(RedBlackNode delete) => SortedMap.MakeRed(this._key, Value, Left, delete);
        protected internal override RedBlackNode Blacken() => new BlackNode(this._key);
        protected internal override RedBlackNode Redden() => throw new InvalidOperationException("Invariant violation");
        protected internal override RedBlackNode Replace(object key, object val, RedBlackNode left, RedBlackNode right) => SortedMap.MakeRed(key, val, left, right);
    }
}

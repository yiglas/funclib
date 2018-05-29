using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    class SortedMapEnumerative :
        Enumerative
    {
        readonly IEnumerative _stack;
        readonly bool _asc;
        readonly int _count;

        public SortedMapEnumerative(IEnumerative stack, bool asc) : this(stack, asc, -1) { }
        public SortedMapEnumerative(IEnumerative stack, bool asc, int count)
        {
            this._stack = stack;
            this._asc = asc;
            this._count = count;
        }
        public SortedMapEnumerative(RedBlackNode t, bool asc, int count) :
            this(Push(t, null, asc), asc, count)
        { }

        #region Overrides
        public override int Count => this._count < 0 ? base.Count : this._count;
        public override object First() => this._stack.First();
        public override IEnumerative Next()
        {
            var t = this._stack.First() as RedBlackNode;
            var nextStack = Push(this._asc ? t.Right : t.Left, this._stack.Next(), this._asc);
            return nextStack != null
                ? new SortedMapEnumerative(nextStack, this._asc, this._count - 1)
                : null;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        static IEnumerative Push(RedBlackNode t, IEnumerative stack, bool asc)
        {
            while (t != null)
            {
                stack = new Core.Cons().Invoke(t, stack);
                t = asc ? t.Left : t.Right;
            }
            return stack;
        }
    }
}

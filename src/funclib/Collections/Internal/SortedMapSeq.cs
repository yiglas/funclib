using System;
using System.Text;

namespace funclib.Collections.Internal
{
    class SortedMapSeq :
        ASeq
    {
        readonly ISeq _stack;
        readonly bool _asc;
        readonly int _count;

        public SortedMapSeq(ISeq stack, bool asc) : this(stack, asc, -1) { }
        public SortedMapSeq(ISeq stack, bool asc, int count)
        {
            this._stack = stack;
            this._asc = asc;
            this._count = count;
        }
        public SortedMapSeq(RedBlackNode t, bool asc, int count) :
            this(Push(t, null, asc), asc, count)
        { }

        #region Overrides
        public override int Count => this._count < 0 ? base.Count : this._count;
        public override object First() => this._stack.First();
        public override ISeq Next()
        {
            var t = this._stack.First() as RedBlackNode;
            var nextStack = Push(this._asc ? t.Right : t.Left, this._stack.Next(), this._asc);
            return nextStack != null
                ? new SortedMapSeq(nextStack, this._asc, this._count - 1)
                : null;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        static ISeq Push(RedBlackNode t, ISeq stack, bool asc)
        {
            while (t != null)
            {
                stack = (ISeq)new Components.Core.Cons().Invoke(t, stack);
                t = asc ? t.Left : t.Right;
            }
            return stack;
        }
    }
}

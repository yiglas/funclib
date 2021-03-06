﻿using funclib.Components.Core;
using System;

namespace funclib.Collections.Internal
{
    abstract class RedBlackNode :
        AKeyValuePair
    {
        protected readonly object _key;

        public RedBlackNode(object key)
        {
            this._key = key;
        }

        #region Overrides
        public override object Key => this._key;
        #endregion

        #region Abstract Methods
        public override abstract object Value { get; }
        protected internal abstract RedBlackNode AddLeft(RedBlackNode insert);
        protected internal abstract RedBlackNode AddRight(RedBlackNode insert);
        protected internal abstract RedBlackNode RemoveLeft(RedBlackNode delete);
        protected internal abstract RedBlackNode RemoveRight(RedBlackNode delete);
        protected internal abstract RedBlackNode Blacken();
        protected internal abstract RedBlackNode Redden();
        protected internal abstract RedBlackNode Replace(object key, object val, RedBlackNode left, RedBlackNode right);
        #endregion

        #region Virtual Methods
        protected internal virtual RedBlackNode Left => null;
        protected internal virtual RedBlackNode Right => null;
        protected internal virtual RedBlackNode BalanceLeft(RedBlackNode parent) => SortedMap.MakeBlack(parent.Key, parent.Value, this, parent.Right);
        protected internal virtual RedBlackNode BalanceRight(RedBlackNode parent) => SortedMap.MakeBlack(parent.Key, parent.Value, parent.Left, this);
        #endregion

        public override ITransientCollection ToTransient() => throw new InvalidOperationException();

        public object Reduce(object f, object init)
        {
            if (Left != null)
            {
                init = Left.Reduce(f, init);
                if (init is Reduced)
                    return init;
            }
            init = funclib.Core.Invoke(f, init, Key, Value);
            if (init is Reduced)
                return init;
            if (Right != null)
                init = Right.Reduce(f, init);

            return init;
        }
    }
}

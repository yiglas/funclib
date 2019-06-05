using System;

namespace funclib.Collections.Generic.Internal
{
    abstract class RedBlackNode<TKey, TValue> :
        AKeyValuePair<TKey, TValue>
    {
        protected readonly TKey _key;

        public RedBlackNode(TKey key)
        {
            this._key = key;
        }

        #region Overrides
        public override TKey Key => this._key;
        public override ITransientCollection<UnionType<TKey, TValue>> ToTransient() => throw new InvalidOperationException();
        #endregion

        #region Abstract Methods
        public override abstract TValue Value { get; }
        protected internal abstract RedBlackNode<TKey, TValue> AddLeft(RedBlackNode<TKey, TValue> insert);
        protected internal abstract RedBlackNode<TKey, TValue> AddRight(RedBlackNode<TKey, TValue> insert);
        protected internal abstract RedBlackNode<TKey, TValue> RemoveLeft(RedBlackNode<TKey, TValue> delete);
        protected internal abstract RedBlackNode<TKey, TValue> RemoveRight(RedBlackNode<TKey, TValue> delete);
        protected internal abstract RedBlackNode<TKey, TValue> Blacken();
        protected internal abstract RedBlackNode<TKey, TValue> Redden();
        protected internal abstract RedBlackNode<TKey, TValue> Replace(TKey key, TValue val, RedBlackNode<TKey, TValue> left, RedBlackNode<TKey, TValue> right);
        #endregion

        #region Virtual Methods
        protected internal virtual RedBlackNode<TKey, TValue> Left => null;
        protected internal virtual RedBlackNode<TKey, TValue> Right => null;
        protected internal virtual RedBlackNode<TKey, TValue> BalanceLeft(RedBlackNode<TKey, TValue> parent) => throw new NotImplementedException("TODO"); // SortedMap<TKey, TValue>.MakeBlack(parent.Key, parent.Value, this, parent.Right);
        protected internal virtual RedBlackNode<TKey, TValue> BalanceRight(RedBlackNode<TKey, TValue> parent) => throw new NotImplementedException("TODO"); // SortedMap<TKey, TValue>.MakeBlack(parent.Key, parent.Value, parent.Left, this);
        #endregion

        public RedBlackNode<TKey, TValue> Reduce(Func<RedBlackNode<TKey, TValue>, TKey, TValue, RedBlackNode<TKey, TValue>> f, RedBlackNode<TKey, TValue> init)
        {
            if (Left != null)
            {
                init = Left.Reduce(f, init);
            }
            init = f(init, Key, Value);
            if (Right != null)
            {
                init = Right.Reduce(f, init);
            }
            return init;
        }
    }
}
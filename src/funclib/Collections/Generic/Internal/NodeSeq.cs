using System;

namespace funclib.Collections.Generic.Internal
{
    sealed class NodeSeq<TKey, TValue> :
        ASeq<IKeyValuePair<TKey, TValue>>
    {
         readonly UnionType<TKey, TValue, INode<TKey, TValue>>[] _array;
        readonly int _i;
        readonly ISeq<IKeyValuePair<TKey, TValue>> _e;

        public NodeSeq(UnionType<TKey, TValue, INode<TKey, TValue>>[] array, int i)
            : this(array, i, null) { }

        public NodeSeq(UnionType<TKey, TValue, INode<TKey, TValue>>[] array, int i, ISeq<IKeyValuePair<TKey, TValue>> e)
        {
            this._array = array;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static ISeq<IKeyValuePair<TKey, TValue>> Create(UnionType<TKey, TValue, INode<TKey, TValue>>[] array) => Create(array, 0, null);
        public static ISeq<IKeyValuePair<TKey, TValue>> Create(UnionType<TKey, TValue, INode<TKey, TValue>>[] array, int i, ISeq<IKeyValuePair<TKey, TValue>> e)
        {
            if (e != null)
            {
                return new NodeSeq<TKey, TValue>(array, i, e);
            }

            for (int j = i; j < array.Length; j += 2)
            {
                if (array[j] != null)
                {
                    return new NodeSeq<TKey, TValue>(array, j, null);
                }

                var node = array[j + 1];
                if (node.IsItem3)
                {
                    var enumerative = node.Item3.GetNodeEnumerative();
                    if (enumerative != null)
                    {
                        return new NodeSeq<TKey, TValue>(array, j + 2, enumerative);
                    }
                }
            }

            return null;
        }
        #endregion

        #region Overrides
        public override IKeyValuePair<TKey, TValue> First()
        {
            if (this._e != null)
            {
                return this._e.First().Item1;
            }

            return KeyValuePair<TKey, TValue>.Create(this._array[this._i], this._array[this._i + 1]);
        }

        public override ISeq<IKeyValuePair<TKey, TValue>> Next()
        {
            if (this._e != null)
            {
                return Create(this._array, this._i, this._e.Next());
            }

            return Create(this._array, this._i + 2, null);
        }

        public override IStack<IKeyValuePair<TKey, TValue>> Pop() => throw new NotImplementedException();
        #endregion

        public static TAccumulate Reduce<TAccumulate>(UnionType<TKey, TValue, INode<TKey, TValue>>[] array, Func<TAccumulate, UnionType<TKey, TValue, INode<TKey, TValue>>, UnionType<TKey, TValue, INode<TKey, TValue>>, TAccumulate> f, TAccumulate init)
        {
            for (int i = 0; i < array.Length; i += 2)
            {
                if (array[i] != null)
                {
                    init = f(init, array[i], array[i + 1]);
                }
                else
                {
                    var node = array[i + 1];
                    if (node.IsItem3)
                    {
                        init = node.Item3.Reduce(f, init);
                    }
                }
            }

            return init;
        }
    }
}
using System;
using funclib.Collections.Generic.Internal;

namespace funclib.Collections.Generic
{
    public class ArrayChunked<T> :
        IChunked<T>
    {
        readonly UnionType<T, VectorNode<T>>[] _array;
        readonly int _off;
        readonly int _end;

        public ArrayChunked(UnionType<T, VectorNode<T>>[] array, int off) :
            this(array, off, array.Length) { }

        public ArrayChunked(UnionType<T, VectorNode<T>>[] array, int off, int end)
        {
            this._array = array;
            this._off = off;
            this._end = end;
        }

        public T this[int index] { get => this._array[this._off + index]; set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ArrayChunked)}."); }
        public T this[int index, T notFound]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return this[index];
                }

                return notFound;
            }
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ArrayChunked)}.");
        }

        public int Count => this._end - this._off;

        public IChunked<T> DropFirst()
        {
            if (this._off == this._end)
            {
                throw new InvalidOperationException($"{nameof(DropFirst)} of empty {nameof(ArrayChunked)}");
            }

            return new ArrayChunked<T>(this._array, this._off + 1, this._end);
        }

        public TResult Reduce<TResult>(Func<TResult, T, TResult> f, TResult init)
        {
            var ret = f(init, this._array[this._off]);

            for (int x = this._off + 1; x < this._end; x++)
            {
                ret = f(ret, this._array[x]);
            }

            return ret;
        }
    }
}
using funclib.Components.Core;
using System;
using System.Text;

namespace funclib.Collections
{
    public class ArrayChunked :
        IChunked
    {
        readonly object[] _array;
        readonly int _off;
        readonly int _end;

        public ArrayChunked(object[] array, int off) :
            this (array, off, array.Length) { }

        public ArrayChunked(object[] array, int off, int end)
        {
            this._array = array;
            this._off = off;
            this._end = end;
        }

        public object this[int index] { get => this._array[this._off + index]; set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ArrayChunked)}."); }
        public object this[int index, object notFound] {
            get => index >= 0 && index < Count ? this[index] : notFound;
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ArrayChunked)}."); }

        public int Count => this._end - this._off;

        public IChunked DropFirst() =>
            this._off == this._end
                ? throw new InvalidOperationException($"{nameof(DropFirst)} of empty {nameof(ArrayChunked)}")
                : new ArrayChunked(this._array, this._off + 1, this._end);

        public object Reduce(IFunction<object, object, object> f, object init)
        {
            var ret = f.Invoke(init, this._array[this._off]);
            if (ret is Reduced r)
                return r.Deref();

            for (int x = this._off + 1; x < this._end; x++)
            {
                ret = f.Invoke(ret, this._array[x]);
                if (ret is Reduced r2)
                    return r2.Deref();
            }

            return ret;
        }
    }
}

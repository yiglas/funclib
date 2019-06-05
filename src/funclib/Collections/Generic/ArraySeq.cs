using funclib.Collections.Generic.Internal;
using System;

namespace funclib.Collections.Generic
{
    public class ArraySeq<T> :
        ASeq<T>,
        IArray<T>,
        IReduce<T>
    {
        readonly T[] _array;
        readonly int _index;

        ArraySeq(T[] array, int index)
        {
            this._array = array;
            this._index = index;
        }

        #region Creates
        public static ArraySeq<T> Create(T[] array) => new ArraySeq<T>(array, 0);
        #endregion

        #region Virtual Methods
        public virtual ISeq<T> NextOne() => new ArraySeq<T>(this._array, this._index + 1);
        #endregion

        #region Overrides
        public override int Count => this._array.Length - this._index;
        public override T First() => this._array[this._index];
        public override ISeq<T> Next() => this._index + 1 < this._array.Length ? NextOne() : null;
        public override int IndexOf(T value)
        {
            for (int j = this._index; j < this._array.Length; j++)
            {
                if (value.Equals(this._array[j]))
                {
                    return j - this._index;
                }
            }

            return -1;
        }
        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion

        public int Index() => this._index;
        public T[] Array() => this._array;

        public T[] ToArray()
        {
            var items = new T[this._array.Length];
            for (int i = 0; i < this._array.Length; i++)
            {
                items[i] = this._array[i];
            }
            return items;
        }

        public T Reduce(Func<T, T, T> f)
        {
            if (this._array is null) return default;

            var ret = this._array[this._index];

            for (var x = this._index + 1; x < this._array.Length; x++)
            {
                ret = f(ret, this._array[x]);
            }

            return ret;
        }
        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, T, TAccumulate> f, TAccumulate init)
        {
            if (this._array is null) return default;

            var ret = f(init, this._array[this._index]);

            for (var x = this._index + 1; x < this._array.Length; x++)
            {
                ret = f(ret, this._array[x]);
            }

            return ret;
        }
    }
}

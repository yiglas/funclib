using funclib.Collections.Internal;
using funclib.Components.Core;
using System;

namespace funclib.Collections
{
    public class ArraySeq :
        ASeq,
        IArray,
        IReduce
    {
        readonly object[] _array;
        readonly int _index;

        ArraySeq(object[] array, int index)
        {
            this._array = array;
            this._index = index;
        }

        #region Creates
        public static ArraySeq Create(object[] array) => new ArraySeq(array, 0);
        #endregion

        #region Virtual Methods
        public virtual ISeq NextOne() => new ArraySeq(this._array, this._index + 1);
        #endregion

        #region Overrides
        public override int Count => this._array.Length - this._index;
        public override object First() => this._array[this._index];
        public override ISeq Next() => this._index + 1 < this._array.Length ? NextOne() : null;
        public override int IndexOf(object value)
        {
            for (int j = this._index; j < this._array.Length; j++)
                if (value.Equals(this._array[j]))
                    return j - this._index;
            return -1;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public int Index() => this._index;
        public object[] ToArray()
        {
            var items = new object[this._array.Length];
            for (int i = 0; i < this._array.Length; i++)
                items[i] = this._array[i];
            return items;
        }
        public object Reduce(object f)
        {
            if (this._array is null) return null;

            var ret = this._array[this._index];
            for (var x = this._index + 1; x < this._array.Length; x++)
            {
                ret = funclib.Core.Invoke(f, ret, this._array[x]);
                if (ret is Reduced r)
                    return r.Deref();
            }

            return ret;
        }
        public object Reduce(object f, object init)
        {
            if (this._array is null) return null;

            var ret = funclib.Core.Invoke(f, init, this._array[this._index]);
            for (var x = this._index + 1; x < this._array.Length; x++)
            {
                if (ret is Reduced r)
                    return r.Deref();
                ret = funclib.Core.Invoke(f, ret, this._array[x]);
            }
            if (ret is Reduced r2)
                return r2.Deref();

            return ret;
        }

        object IArray.Array() => this._array;
    }
}

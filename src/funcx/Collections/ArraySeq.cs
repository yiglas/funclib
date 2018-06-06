using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    public class ArraySeq :
        ASeq,
        IArray
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
        #endregion

        public int Index() => this._index;
        public override IStack Pop() => throw new NotImplementedException();
        public object[] ToArray()
        {
            var items = new object[this._array.Length];
            for (int i = 0; i < this._array.Length; i++)
                items[i] = this._array[i];
            return items;
        }

        object IArray.Array() => this._array;
    }
}

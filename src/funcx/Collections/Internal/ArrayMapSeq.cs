using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    sealed class ArrayMapSeq :
        ASeq
    {
        readonly object[] _array;
        readonly int _i;

        public ArrayMapSeq(object[] array, int i)
        {
            this._array = array;
            this._i = i;
        }

        #region Overrides
        public override int Count => (this._array.Length - this._i) / 2;
        public override object First() => new KeyValuePair(this._array[this._i], this._array[this._i + 1]);
        public override ISeq Next() => this._i + 2 < this._array.Length ? new ArrayMapSeq(this._array, this._i + 2) : null;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

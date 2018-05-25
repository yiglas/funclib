using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class ArrayEnumerative :
        Enumerative
    {
        readonly object[] _array;
        readonly int _i;

        public ArrayEnumerative(object[] array, int i)
        {
            this._array = array;
            this._i = i;
        }

        #region Overrides
        public override int Count => (this._array.Length - this._i) / 2;
        public override object First() => new KeyValuePair<object, object>(this._array[this._i], this._array[this._i + 1]);
        public override IEnumerative Next() => this._i + 2 < this._array.Length ? new ArrayEnumerative(this._array, this._i + 2) : null;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

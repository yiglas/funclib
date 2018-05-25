using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class NodeEnumerative :
        Enumerative
    {
        readonly object[] _array;
        readonly int _i;
        readonly IEnumerative _e;

        public NodeEnumerative(object[] array, int i)
            : this(array, i, null) { }

        public NodeEnumerative(object[] array, int i, IEnumerative e)
        {
            this._array = array;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static IEnumerative Create(object[] array) => Create(array, 0, null);
        public static IEnumerative Create(object[] array, int i, IEnumerative e)
        {
            if (e != null) return new NodeEnumerative(array, i, e);

            for (int j = i; j < array.Length; j += 2)
            {
                if (array[j] != null) return new NodeEnumerative(array, j, null);

                var node = (INode)array[j + 1];
                if (node != null)
                {
                    var enumerative = node.GetNodeEnumerative();
                    if (enumerative != null)
                        return new NodeEnumerative(array, j + 2, enumerative);
                }
            }

            return null;
        }
        #endregion

        #region Overrides
        public override object First() =>
            this._e != null
                ? this._e.First()
                : new KeyValuePair<object, object>(this._array[this._i], this._array[this._i + 1]);

        public override IEnumerative Next() =>
            this._e != null
                ? Create(this._array, this._i, this._e.Next())
                : Create(this._array, this._i + 2, null);

        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}

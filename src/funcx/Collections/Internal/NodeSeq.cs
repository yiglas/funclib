using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    sealed class NodeSeq :
        ASeq
    {
        readonly object[] _array;
        readonly int _i;
        readonly ISeq _e;

        public NodeSeq(object[] array, int i)
            : this(array, i, null) { }

        public NodeSeq(object[] array, int i, ISeq e)
        {
            this._array = array;
            this._i = i;
            this._e = e;
        }

        #region Creates
        public static ISeq Create(object[] array) => Create(array, 0, null);
        public static ISeq Create(object[] array, int i, ISeq e)
        {
            if (e != null) return new NodeSeq(array, i, e);

            for (int j = i; j < array.Length; j += 2)
            {
                if (array[j] != null) return new NodeSeq(array, j, null);

                var node = (INode)array[j + 1];
                if (node != null)
                {
                    var enumerative = node.GetNodeEnumerative();
                    if (enumerative != null)
                        return new NodeSeq(array, j + 2, enumerative);
                }
            }

            return null;
        }
        #endregion

        #region Overrides
        public override object First() =>
            this._e != null
                ? this._e.First()
                : new System.Collections.Generic.KeyValuePair<object, object>(this._array[this._i], this._array[this._i + 1]);

        public override ISeq Next() =>
            this._e != null
                ? Create(this._array, this._i, this._e.Next())
                : Create(this._array, this._i + 2, null);

        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public static object Reduce(object[] array, IFunction<object, object, object, object> f, object init)
        {
            for (int i = 0; i < array.Length; i += 2)
            {
                if (array[i] != null)
                    init = f.Invoke(init, array[i], array[i + 1]);
                else
                {
                    var node = (INode)array[i + 1];
                    if (node != null)
                        init = node.Reduce(f, init);
                }
                if ((bool)new IsReduced().Invoke(init))
                    return init;
            }

            return init;
        }

    }
}

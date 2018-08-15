using System;
using System.Collections;

namespace funclib.Collections
{
    public sealed class SubVector :
        AVector
    {
        readonly IVector _v;
        readonly int _start;
        readonly int _end;

        SubVector(IVector v, int start, int end)
        {
            if (v is SubVector sv)
            {
                start += sv._start;
                end += sv._start;
                v = sv._v;
            }

            this._v = v;
            this._start = start;
            this._end = end;
        }

        #region Creates
        public static SubVector Create(IVector v, int start, int end) => new SubVector(v, start, end);
        #endregion

        #region Overrides
        public override int Count => this._end - this._start;
        public override ICollection Empty() => Vector.EMPTY;
        public override object this[int index]
        {
            get => this._start + index >= this._end || index < 0
                    ? throw new IndexOutOfRangeException($"Index was outside the bounds of the {nameof(SubVector)}.")
                    : this._v[this._start + index];
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(SubVector)}.");
        }
        public override IVector Assoc(int i, object val) =>
            this._start + 1 > this._end
                ? throw new ArgumentOutOfRangeException(nameof(i))
                : this._start + 1 == this._end ? Cons(val)
                : new SubVector(this._v.Assoc(this._start + 1, val), this._start, this._end);
        public override IVector Cons(object o) => new SubVector(this._v.Assoc(this._end, o), this._start, this._end + 1);
        public override IStack Pop() =>
            this._end - 1 == this._start
                ? Vector.EMPTY
                : new SubVector(this._v, this._start, this._end - 1);
        public override IEnumerator GetEnumerator()
        {
            if (this._v is AVector av)
                return av.RangedEnumerator(this._start, this._end);

            return base.GetEnumerator();
        }
        public override ITransientCollection ToTransient() => throw new NotImplementedException();
        #endregion
    }
}

using funclib.Collections.Internal;
using funclib.Components.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections
{
    public class Queue :
        IQueue
    {
        [NonSerialized]
        protected int _hash = 0;

        public static readonly IQueue EMPTY = new Queue(0, null, null);

        readonly ISeq _f;
        readonly IVector _r;

        public int Count { get; }
        public bool IsSynchronized => true;
        public object SyncRoot => this;

        internal Queue(int count, ISeq f, IVector r)
        {
            Count = count;
            this._f = f;
            this._r = r;
        }

        #region Overrides
        public override string ToString() => Util.Print(this);

        public override bool Equals(object obj)
        {
            if (!(obj is ISequential)) return false;

            var ms = (ISeq)new Seq().Invoke(obj);
            for (var e = Seq(); e != null; e = e.Next(), ms = ms.Next())
                if (ms == null || !(bool)new IsEqual().Invoke(e.First(), ms.First()))
                    return false;

            return ms == null;
        }

        public override int GetHashCode()
        {
            var hash = this._hash;
            if (hash == 0)
            {
                for (var e = Seq(); e != null; e = e.Next())
                    hash = 31 * hash + (e.First() == null ? 0 : e.First().GetHashCode());

                this._hash = hash;
            }
            return hash;
        }
        #endregion

        public object Peek() => new First().Invoke(this._f);
        public IStack Pop()
        {
            if (this._f == null) return this;
            var f1 = this._f.Next();
            var r1 = this._r;

            if (f1 == null)
            {
                f1 = (ISeq)new Seq().Invoke(this._r);
                r1 = null;
            }
            return new Queue(Count - 1, f1, r1);
        }
        public ICollection Cons(object o) => throw new NotImplementedException();
        public ICollection Empty() => EMPTY;
        public ISeq Seq() => this._f == null ? null : new QueueSeq(this._f, (ISeq)new Seq().Invoke(this._r));
        public void CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("Array must be 1-dimensional.");
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Must be no-negative.");
            if (array.Length - index < Count) throw new InvalidOperationException("The number of elements in source is greater than the available space in the array.");

            var i = index;
            for (var s = this._f; s != null; s = s.Next(), i++)
                array.SetValue(s.First(), i);

            if (this._r != null)
            {
                for (var s = this._r.Seq(); s != null; s = s.Next(), i++)
                    array.SetValue(s.First(), i);
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (var s = this._f; s != null; s = s.Next())
                yield return s.First();

            if (this._r != null)
            {
                for (var s = this._r.Seq(); s != null; s = s.Next())
                    yield return s.First();
            }
        }
    }
}

using funclib.Collections.Internal;
using funclib.Components.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections
{
    public class Range :
        ASeq,
        IChunkedSeq,
        IReduce
    {
        readonly object _start;
        readonly object _end;
        readonly object _step;
        readonly IBoundsCheck _boundsCheck;

        volatile IChunked _chunk;
        volatile ISeq _chunkNext;
        volatile ISeq _next;

        Range(object start, object end, object step, IBoundsCheck boundsCheck) :
            this(start, end, step, boundsCheck, null, null)
        { }

        Range(object start, object end, object step, IBoundsCheck boundsCheck, IChunked chunk, ISeq chunkNext)
        {
            this._start = start;
            this._end = end;
            this._step = step;
            this._boundsCheck = boundsCheck;
            this._chunk = chunk;
            this._chunkNext = chunkNext;
        }

        #region Creates
        public static ISeq Create(object end)
        {
            if (Numbers.IsPos(end))
                return new Range(0L, end, 1L, new PositiveStepCheck(end));

            return List.EMPTY;
        }

        public static ISeq Create(object start, object end) => Create(start, end, 1L);

        public static ISeq Create(object start, object end, object step)
        {
            if ((Numbers.IsPos(step) && Numbers.IsGT(start, end)) 
                || (Numbers.IsNeg(step) && Numbers.IsGT(end, start)) 
                || Numbers.IsEqual(start, end))
                return List.EMPTY;
            if (Numbers.IsZero(step)) return Repeat.Create(start);

            return new Range(start, end, step, Numbers.IsPos(step) ? new PositiveStepCheck(end) : (IBoundsCheck)new NegativeStepCheck(end));
        }
        #endregion

        #region Overrides
        public override object First() => this._start;
        public override ISeq Next()
        {
            if (this._next != null) return this._next;

            ForceChunk();
            if (this._chunk.Count > 1)
            {
                var smallerChunk = this._chunk.DropFirst();
                this._next = new Range(smallerChunk[0], this._end, this._step, this._boundsCheck, smallerChunk, this._chunkNext);
                return this._next;
            }
            return ChunkedNext();
        }
        public override IEnumerator GetEnumerator()
        {
            object next = this._start;
            while (!this._boundsCheck.ExceededBounds(next))
            {
                yield return next;
                next = Numbers.Add(next, this._step);
            }
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public object Reduce(IFunction f)
        {
            var acc = this._start;
            var i = Numbers.Add(this._start, this._step);
            while (!this._boundsCheck.ExceededBounds(i))
            {
                acc = ((IFunction<object, object, object>)f).Invoke(acc, i);
                if (acc is Reduced r)
                    return r.Deref();
                i = Numbers.Add(i, this._step);
            }
            return acc;
        }
        public object Reduce(IFunction f, object init)
        {
            var acc = init;
            var i = this._start;
            while (!this._boundsCheck.ExceededBounds(i))
            {
                acc = ((IFunction<object, object, object>)f).Invoke(acc, i);
                if (acc is Reduced r)
                    return r.Deref();
                i = Numbers.Add(i, this._step);
            }
            return acc;
        }

        public IChunked ChunkedFirst() { ForceChunk(); return this._chunk; }
        public ISeq ChunkedMore()
        {
            ForceChunk();
            if (this._chunkNext == null) return List.EMPTY;
            return this._chunkNext;
        }
        public ISeq ChunkedNext() => ChunkedMore().Seq();

        void ForceChunk()
        {
            if (this._chunk != null) return;
            var arr = new object[Constants.CHUNK_SIZE];
            int n = 0;
            var val = this._start;
            while (n < Constants.CHUNK_SIZE)
            {
                arr[n++] = val;
                val = Numbers.Add(val, this._step);
                if (this._boundsCheck.ExceededBounds(val))
                {
                    this._chunk = new ArrayChunked(arr, 0, n); // partial last chunk
                    return;
                }
            }

            // full last chunk
            if (this._boundsCheck.ExceededBounds(val))
            {
                this._chunk = new ArrayChunked(arr, 0, Constants.CHUNK_SIZE);
                return;
            }

            // full intermediate chunk
            this._chunk = new ArrayChunked(arr, 0, Constants.CHUNK_SIZE);
            this._chunkNext = new Range(val, this._end, this._step, this._boundsCheck);
        }
    }
}

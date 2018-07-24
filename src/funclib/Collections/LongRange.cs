using funclib.Collections.Internal;
using funclib.Components.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Collections
{
    public class LongRange :
        ASeq,
        IChunkedSeq,
        IReduce
    {
        readonly long _start;
        readonly long _end;
        readonly long _step;
        readonly IBoundsCheck _boundsCheck;
        volatile IChunked _chunk;
        volatile ISeq _chunkNext;
        volatile ISeq _next;

        LongRange(long start, long end, long step, IBoundsCheck boundsCheck) :
            this(start, end, step, boundsCheck, null, null)
        { }

        LongRange(long start, long end, long step, IBoundsCheck boundsCheck, IChunked chunk, ISeq chunkNext)
        {
            this._start = start;
            this._end = end;
            this._step = step;
            this._boundsCheck = boundsCheck;
            this._chunk = chunk;
            this._chunkNext = chunkNext;
        }

        #region Creates
        public static ISeq Create(long end)
        {
            if (end > 0)
                return new LongRange(0L, end, 1L, new PositiveStepCheck(end));

            return List.EMPTY;
        }

        public static ISeq Create(long start, long end) => Create(start, end, 1L);

        public static ISeq Create(long start, long end, long step)
        {
            if (step > 0)
            {
                if (end <= start)
                    return List.EMPTY;

                return new LongRange(start, end, step, new PositiveStepCheck(end));
            }
            else if (step < 0)
            {
                if (end >= start)
                    return List.EMPTY;

                return new LongRange(start, end, step, new NegativeStepCheck(end));
            }
            else
            {
                if (end == start)
                    return List.EMPTY;

                return Repeat.Create(start);
            }
        }
        #endregion

        #region Overrides
        public override int Count
        {
            get
            {
                try
                {
                    var count = RangeCount(this._start, this._end, this._step);

                    return count > int.MaxValue
                        ? throw new ArithmeticException("Int overflow")
                        : (int)count;
                }
                catch (ArithmeticException)
                {
                    var enumerator = GetEnumerator();
                    long count = 0;
                    while (enumerator.MoveNext())
                        count++;

                    return count > int.MaxValue
                        ? throw new ArithmeticException("Int overflow")
                        : (int)count;
                }
            }
        }
        public override object First() => this._start;
        public override ISeq Next()
        {
            if (this._next != null) return this._next;

            ForceChunk();
            if (this._chunk.Count > 1)
            {
                var smallerChunk = (LongChunked)this._chunk.DropFirst();
                this._next = new LongRange(smallerChunk.First(), this._end, this._step, this._boundsCheck, smallerChunk, this._chunkNext);
                return this._next;
            }

            return ChunkedNext();
        }
        public override IStack Pop() => throw new NotImplementedException();
        public override IEnumerator GetEnumerator()
        {
            object next = this._start;
            while (!_boundsCheck.ExceededBounds(next))
            {
                yield return next;
                try
                {
                    next = Numbers.Add(next, this._step);
                }
                catch (ArithmeticException) { yield break; }
            }
        }
        #endregion

        public IChunked ChunkedFirst()
        {
            ForceChunk();
            return this._chunk;
        }
        public ISeq ChunkedMore()
        {
            ForceChunk();
            if (this._chunk is null) return List.EMPTY;
            return this._chunkNext;
        }

        public ISeq ChunkedNext() => ChunkedMore().Seq();
        public object Reduce(object f)
        {
            object acc = this._start;
            long i = this._start + this._step;
            while (!this._boundsCheck.ExceededBounds(i))
            {
                acc = invoke(f, acc, i);
                if (acc is Reduced r)
                    return r.Deref();
                i += this._step;
            }
            return acc;
        }
        public object Reduce(object f, object init)
        {
            var acc = init;
            long i = this._start;
            do
            {
                acc = invoke(f, acc, i);
                if (acc is Reduced r)
                    return r.Deref();
                i += this._step;
            } while (!this._boundsCheck.ExceededBounds(i));
            return acc;
        }


        void ForceChunk()
        {
            if (this._chunk != null) return;

            long count;
            try
            {
                count = RangeCount(this._start, this._end, this._step);
            }
            catch (ArithmeticException)
            {
                count = SteppingCount(this._start, this._end, this._step);
            }

            if (count > Constants.CHUNK_SIZE)
            {
                var nextStart = this._start + (this._step * Constants.CHUNK_SIZE);
                this._chunkNext = new LongRange(nextStart, this._end, this._step, this._boundsCheck);
                this._chunk = new LongChunked(this._start, this._step, Constants.CHUNK_SIZE);
            }
            else
                this._chunk = new LongChunked(this._start, this._step, (int)count);
        }

        long SteppingCount(long start, long end, long step)
        {
            long count = 1;
            object s = this._start;

            while (count <= Constants.CHUNK_SIZE)
            {
                try
                {
                    s = Numbers.Add(s, step);
                    if (this._boundsCheck.ExceededBounds(s)) break;
                    count++;
                }
                catch (ArithmeticException) { break; }
            }

            return count;
        }

        long RangeCount(long start, long end, long step) =>
            (long)Numbers.Add(Numbers.Add(Numbers.Subtract(end, start), step), this._step > 0 ? -1 : 1) / step;
    }
}

using funclib.Components.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Collections.Internal
{
    class LongChunked :
        IChunked
    {
        readonly long _start;
        readonly long _step;

        public LongChunked(long start, long step, int count)
        {
            this._start = start;
            this._step = step;
            Count = count;
        }

        public object this[int index] { get => this._start + (index * this._step); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(LongChunked)}."); }
        public object this[int index, object notFound] {
            get =>
                index >= 0 && index < Count
                    ? this[index]
                    : notFound;
            set => throw new NotImplementedException(); }

        public int Count { get; }

        public IChunked DropFirst() =>
            Count <= 1
                ? throw new InvalidOperationException("DropFirst of empty chunk")
                : new LongChunked(this._start + this._step, this._step, Count - 1);

        public object Reduce(object f, object init)
        {
            var x = this._start;
            var ret = init;
            for (int i = 0; i < Count; i++)
            {
                ret = invoke(f, ret, x);
                if (ret is Reduced r)
                    return r.Deref();
                x += this._step;
            }
            return ret;
        }

        public long First() => this._start;
    }
}

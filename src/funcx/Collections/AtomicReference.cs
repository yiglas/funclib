using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace funcx.Collections
{
    public class AtomicReference<T>
        where T : class
    {
        T _ref;

        public AtomicReference() : this(null) { }
        public AtomicReference(T init)
        {
            this._ref = init;
        }

        public bool CompareAndSet(T expected, T update)
        {
            var old = Interlocked.CompareExchange(ref this._ref, update, expected);
            return ReferenceEquals(old, expected);
        }

        public T Get() => this._ref;

        public T GetAndSet(T update) => Interlocked.Exchange(ref this._ref, update);
        public void Set(T update) => GetAndSet(update);

        public override string ToString() => this._ref.ToString();
    }
}

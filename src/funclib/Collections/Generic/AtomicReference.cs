using System.Threading;

namespace funclib.Collections.Generic
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
            return funclib.Core.E(old, expected);
        }

        public T Get() => this._ref;

        public T GetAndSet(T update) => Interlocked.Exchange(ref this._ref, update);
        public void Set(T update) => GetAndSet(update);

        public override string ToString() => this._ref.ToString();
    }
}

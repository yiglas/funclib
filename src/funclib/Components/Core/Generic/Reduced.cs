using funclib.Components.Core.Generic;

namespace funclib.Components.Core.Generic
{
    public class Reduced<T> :
        IDeref<T>,
        IFunction<T, Reduced<T>>
    {
        readonly T _val;

        Reduced(T val) => this._val = val;

        public Reduced()
        {
        }

        public T Deref() => this._val;

        public Reduced<T> Invoke(T x) => new Reduced<T>(x);
    }
}

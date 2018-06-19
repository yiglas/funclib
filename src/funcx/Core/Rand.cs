using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Rand :
        IFunction<object>,
        IFunction<object, object>
    {
        static readonly Random _random = new Random();

        public object Invoke() => new Locking(_random, () => _random.NextDouble()).Invoke();
        public object Invoke(object n) => Numbers.Multiply(n, Invoke());
    }
}

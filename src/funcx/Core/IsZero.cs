using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsZero :
        IFunction<long, bool>,
        IFunction<int, bool>,
        IFunction<double, bool>,
        IFunction<float, bool>
    {
        public bool Invoke(long n) => n == 0;
        public bool Invoke(int n) => n == 0;
        public bool Invoke(double n) => n == 0;
        public bool Invoke(float n) => n == 0;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Inc :
        IFunction<long, long>,
        IFunction<int, int>,
        IFunction<double, double>,
        IFunction<float, float>
    {
        public long Invoke(long x) => ++x;
        public int Invoke(int x) => ++x;
        public double Invoke(double x) => ++x;
        public float Invoke(float x) => ++x;
    }
}

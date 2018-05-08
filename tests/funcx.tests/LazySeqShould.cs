using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class LazySeqShould
    {
        [Test]
        public void LazySeq_should_lazy_seq_a_function()
        {
            Func<int, IEnumerable<int>> positiveNumbers = null;
            positiveNumbers = n => lazyseq(() => cons(n, positiveNumbers(inc(n))));

            var actual = toarray(take(5, positiveNumbers(1)));

            Assert.AreEqual(5, actual.Length);
        }

        [Test]
        public void LazySeq_should_play_fibonacci()
        {
            Func<int, int, IEnumerable<int>> fib = null;
            fib = (a, b) => lazyseq(() => cons(a, fib(b, a + b)));

            var actual = toarray(take(5, fib(1, 1)));

            Assert.AreEqual(1, actual[0]);
            Assert.AreEqual(1, actual[1]);
            Assert.AreEqual(2, actual[2]);
            Assert.AreEqual(3, actual[3]);
            Assert.AreEqual(5, actual[4]);
        }

        [Test]
        public void Perfomance()
        {
            var perf = new LazySeqPerformance();
            var results = perf.Measure();

            Assert.Greater(results.baseline, results.b);
        }
    }


    public class LazySeqPerformance : Performance
    {
        const int DEFAULT_ITERATIONS = 30;
        const int LIST_SIZE = 1000;
        const int WORD_SIZE = 5;


        public LazySeqPerformance() : base("LazySeq", "", DEFAULT_ITERATIONS)
        {
        }

        protected override bool BaselineTest()
        {
            for (int i = 0; i < this.Iterations; i++)
            {
                FibonacciSeries(i);
            }
            return true;

            int FibonacciSeries(int n)
            {
                if (n == 0) return 0; //To return the first Fibonacci number   
                if (n == 1) return 1; //To return the second Fibonacci number   
                return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
            }
        }

        protected override bool MeasureTestB()
        {
            Func<int, int, IEnumerable<int>> fib = null;
            fib = (a, b) => lazyseq(() => cons(a, fib(b, a + b)));

            toarray(take(this.Iterations, fib(1, 1)));

            return true;
        }

        protected override bool MeasureTestC() => false;
    }
}

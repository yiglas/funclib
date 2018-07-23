using funclib.Collections;
using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using list = funclib.Collections.List;

namespace funclib.Tests.Components.Core
{
    public class LazySeqShould
    {
        [Test]
        public void LazySeq_should_()
        {
            //var expected = list.Create(1, 2, 3, 4, 5);
            //var actual = toArray(take(5, positive_numbers(1)));

            //Assert.AreEqual(expected, actual);

            //object positive_numbers(object n) => new funclib.Components.Core.LazySeq(() => (ISeq)new funclib.Components.Core.Cons().Invoke(n, positive_numbers(inc(n))));
        }

    //    [Test]
    //    public void LazySeq_should_lazily_evaluate()
    //    {
    //        var 
    //    }

        //[Test]
        //public void LazySeq_should_lazy_seq_a_function()
        //{
        //    Func<int, IEnumerable<int>> positiveNumbers = null;
        //    positiveNumbers = n => lazyseq(() => cons(n, positiveNumbers(inc(n))));

        //    var actual = toarray(take(5, positiveNumbers(1)));

        //    Assert.AreEqual(5, actual.Length);
        //}

        //[Test]
        //public void LazySeq_should_play_fibonacci()
        //{
        //    Func<int, int, IEnumerable<int>> fib = null;
        //    fib = (a, b) => lazyseq(() => cons(a, fib(b, a + b)));

        //    var actual = toarray(take(5, fib(1, 1)));

        //    Assert.AreEqual(1, actual[0]);
        //    Assert.AreEqual(1, actual[1]);
        //    Assert.AreEqual(2, actual[2]);
        //    Assert.AreEqual(3, actual[3]);
        //    Assert.AreEqual(5, actual[4]);
        //}

        //[Test]
        //public void Perfomance()
        //{
        //    var perf = new LazySeqPerformance();
        //    var results = perf.Measure();

        //    Assert.Greater(results.baseline, results.b);
        //}

        //[Test]
        //public void LazySeq_should_do_fibonacci()
        //{
        //    Func<int, int, LazySeq<int>> fib = null;
        //    fib = (a, b) =>
        //        new LazySeq<int>(new Function<IEnumerable<int>>(() => new Cons<int>().Invoke(a, fib(b, a + b))));

        //    var actual = take(5, fib(1, 1)).ToArray();

        //    Assert.AreEqual(5, actual.Length);
        //}

        //[Test]
        //public void LazySeq_should_be_used_in_an_enumerable_list_function()
        //{
        //    Func<int, int, IEnumerable<int>> sumLast2 = null;
        //    sumLast2 = (n, m) =>
        //        new Cons<int>().Invoke(n, new LazySeq<int>(new Function<IEnumerable<int>>(() => sumLast2(m, n + m))));

        //    var actual = take(6, sumLast2(1, 2)).ToList();


        //}
    }

}

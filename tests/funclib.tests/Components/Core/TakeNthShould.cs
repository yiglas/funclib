using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class TakeNthShould
    {
        [Test]
        public void TakeNth_returns_lazyseq()
        {
            var actual = takeNth(2, range(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void TakeNth_returns_every_x_items()
        {
            var expected = list(0, 2, 4, 6, 8);
            var actual = takeNth(2, range(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeNth_returns_an_infinit_loop_when_n_is_less_than_or_equal_to_zero()
        {
            var expected = list(0, 0, 0);
            var actual = take(3, takeNth(0, range(2)));

            Assert.AreEqual(expected, actual);
        }
    }
}

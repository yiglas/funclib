using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class TakeNthShould
    {
        [Test]
        public void TakeNth_returns_lazyseq()
        {
            var actual = new TakeNth().Invoke(2, new Range().Invoke(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void TakeNth_returns_every_x_items()
        {
            var expected = list(0, 2, 4, 6, 8);
            var actual = new TakeNth().Invoke(2, new Range().Invoke(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeNth_returns_an_infinit_loop_when_n_is_less_than_or_equal_to_zero()
        {
            var expected = list(0, 0, 0);
            var actual = new Take().Invoke(3, new TakeNth().Invoke(0, new Range().Invoke(2)));

            Assert.AreEqual(expected, actual);
        }
    }
}

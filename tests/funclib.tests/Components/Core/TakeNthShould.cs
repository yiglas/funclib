using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class TakeNthShould
    {
        [Test]
        public void TakeNth_returns_lazyseq()
        {
            var actual = funclib.Core.TakeNth(2, funclib.Core.Range(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void TakeNth_returns_every_x_items()
        {
            var expected = funclib.Core.List(0, 2, 4, 6, 8);
            var actual = funclib.Core.TakeNth(2, funclib.Core.Range(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeNth_returns_an_infinit_loop_when_n_is_less_than_or_equal_to_zero()
        {
            var expected = funclib.Core.List(0, 0, 0);
            var actual = funclib.Core.Take(3, funclib.Core.TakeNth(0, funclib.Core.Range(2)));

            Assert.AreEqual(expected, actual);
        }
    }
}

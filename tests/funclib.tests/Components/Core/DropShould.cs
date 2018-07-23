using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DropShould
    {
        [Test]
        public void Drop_should_return_a_lazy_seq()
        {
            var actual = drop(1, new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Drop_should_return_all_times_execute_first_n_items()
        {
            var expected = list(3, 4, 5);
            var actual = new ToArray().Invoke(drop(2, list(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}

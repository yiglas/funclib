using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class DropShould
    {
        [Test]
        public void Drop_should_return_a_lazy_seq()
        {
            var actual = new Drop().Invoke(1, new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Drop_should_return_all_times_execute_first_n_items()
        {
            var expected = new funclib.Components.Core.List().Invoke(3, 4, 5);
            var actual = new ToArray().Invoke(new Drop().Invoke(2, new funclib.Components.Core.List().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}

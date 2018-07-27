using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class DropShould
    {
        [Test]
        public void Drop_should_work_with_arrays()
        {
            var expected = list(2, 3);
            var actual = drop(1, new object[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Drop_should_return_a_lazy_seq()
        {
            var actual = drop(1, vector(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Drop_should_return_all_times_execute_first_n_items()
        {
            var expected = list(3, 4, 5);
            var actual = toArray(drop(2, list(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}

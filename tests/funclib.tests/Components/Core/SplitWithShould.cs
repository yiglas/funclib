using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class SplitWithShould
    {
        [Test]
        public void SplitWith_should_split_on_function()
        {
            var expected = vector(list(1, 2, 3), list(4, 5));
            var actual = splitWith(partial(new IsGreaterThanOrEqualTo(), 3), vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitWith_should_return_empty_list_if_greater_function_doesnot_return_records()
        {
            var expected = vector(list(1, 2, 3, 2, 1), list());
            var actual = splitWith(partial(new IsGreaterThan(), 10), vector(1, 2, 3, 2, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}

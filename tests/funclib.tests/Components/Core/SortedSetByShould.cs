using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class SortedSetByShould
    {
        [Test]
        public void SortedSetBy_should_create_new_set_sorted_by_the_function()
        {
            var actual = sortedSetBy(new IsGreaterThan(), 3, 5, 8, 2, 1);

            Assert.AreEqual(8, first(actual));
            Assert.AreEqual(5, second(actual));
            Assert.AreEqual(1, last(actual));
        }
    }
}

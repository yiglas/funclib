using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SortedMapByShould
    {
        [Test]
        public void SortedMapBy_should_create_new_map_sorted_by_the_function()
        {
            var actual = new SortedMapBy().Invoke(new IsGreaterThan(), 1, "a", 2, "b", 3, "c");

            Assert.AreEqual(new Vector().Invoke(3, "c"), first(actual));
            Assert.AreEqual(new Vector().Invoke(2, "b"), new Second().Invoke(actual));
            Assert.AreEqual(new Vector().Invoke(1, "a"), new Last().Invoke(actual));
        }
    }
}

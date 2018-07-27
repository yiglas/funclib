using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class GroupByShould
    {
        [Test]
        public void GroupBy_should_group_a_given_collection_by_the_function()
        {
            var expected = hashMap(false, vector(0, 2, 4, 6, 8), true, vector(1, 3, 5, 7, 9));
            var actual = groupBy(new IsOdd(), range(10));

            Assert.AreEqual(expected, actual);
        }
    }
}

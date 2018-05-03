using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class MapShould
    {
        [Test]
        public void Map_should_iterate_over_enumerable_applying_the_function_to_each_item()
        {
            var expected = new int[] { 2, 3, 4, 5, 6 };
            var actual = map(inc, new int[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(expected[0], actual.ToArray()[0]);
        }

        [Test]
        public void Map_should_iterate_over_enumerables_applying_the_function_to_each_item_until_one_collection_is_done()
        {
            var expected = new int[] { 2, 4, 6 };
            var actual = map((int x, int y) => x + y, new int[] { 1, 2, 3 }, iterate(inc, 1)).ToArray();

            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}

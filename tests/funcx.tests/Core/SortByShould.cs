using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests.Core
{
    public class SortByShould
    {
        [Test]
        public void SortBy_should_sort_by_the_count_of_letters()
        {
            var actual = sortby(count, new string[] { "aaa", "bb", "c" });

            Assert.AreEqual("c", actual[0]);
            Assert.AreEqual("aaa", actual[2]);
        }

        [Test]
        public void SortBy_should_sort_by_the_first_item_in_a_key_val_pair()
        {
            var actual = sortby(first, new List<KeyValuePair<int, int>>() {
                new KeyValuePair<int, int>(1, 2),
                new KeyValuePair<int, int>(2, 2),
                new KeyValuePair<int, int>(2, 3) });

            Assert.AreEqual(1, actual[0].Key);
            Assert.AreEqual(3, actual[2].Value);
        }
    }
}

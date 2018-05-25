using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests.Core
{
    public class GroupByShould
    {
        [Test]
        public void GroupBy_should_group_the_count_of_items_together()
        {
            var actual = groupby(count, new string[] { "a", "as", "asd", "aa", "asdf", "qwer" });

            Assert.AreEqual(1, actual[1].Count);
            Assert.AreEqual(2, actual[2].Count);
            Assert.AreEqual(1, actual[3].Count);
            Assert.AreEqual(2, actual[4].Count);
        }

        [Test]
        public void GroupBy_should_group_by_its_identity()
        {
            var actual = groupby(identity, "abracadabra");

            Assert.AreEqual(5, actual['a'].Count);
            Assert.AreEqual(1, actual['d'].Count);
        }
    }
}

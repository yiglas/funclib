using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class SortShould
    {
        [Test]
        public void Sort_should_order_by_default_if_only_passed_a_list()
        {
            var actual = sort(new int[] { 3, 1, 4, 2 });

            Assert.AreEqual(1, actual[0]);
            Assert.AreEqual(4, actual[3]);
        }

        [Test]
        public void Sort_should_order_by_comparator_when_passed()
        {
            var actual = sort((x, y) => x > y ? 0 : -1, vals(new Dictionary<string, int>() { ["foo"] = 5, ["bar"] = 2, ["baz"] = 10 }));

            Assert.AreEqual(10, actual[0]);
            Assert.AreEqual(2, actual[2]);
        }
    }
}

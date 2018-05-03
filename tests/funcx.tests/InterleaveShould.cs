using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class InterleaveShould
    {
        [Test]
        public void Interleave_should_return_first_item_from_collection_a_then_b_then_repeat_until_one_is_done()
        {
            var actual = interleave(new string[] { "a", "b", "c" }, new int[] { 1, 2, 3 }).ToArray();

            Assert.AreEqual(actual[0], "a");
            Assert.AreEqual(actual[1], 1);
        }
    }
}

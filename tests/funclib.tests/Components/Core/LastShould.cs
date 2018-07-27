using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class LastShould
    {
        [Test]
        public void Last_should_return_last_item_for_a_vector()
        {
            var expected = 5;
            var actual = last(vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Last_should_return_last_KeyValuePair_for_a_map()
        {
            var expected = new funclib.Collections.KeyValuePair(":three", 3);
            var actual = last(arrayMap(":one", 1, ":two", 2, ":three", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}

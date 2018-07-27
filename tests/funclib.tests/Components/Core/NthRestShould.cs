using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class NthRestShould
    {
        [Test]
        public void NthRest_should_skip_the_first_x()
        {
            var expected = list(5, 6, 7, 8, 9);
            var actual = nthRest(range(10), 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NthRest_should_return_empty_collection_if_empty_collection_is_passed()
        {
            var expected = vector();
            var actual = nthRest(vector(), 3);

            Assert.AreEqual(expected, actual);
        }
    }
}

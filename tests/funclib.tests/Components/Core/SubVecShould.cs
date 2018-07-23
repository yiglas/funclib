using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SubVecShould
    {
        [Test]
        public void SubVec_should_return_a_vector()
        {
            var actual = subVec(vector(1, 2, 3, 4, 5, 6, 7), 2);

            Assert.IsInstanceOf<funclib.Collections.IVector>(actual);
        }

        [Test]
        public void SubVec_should_return_all_items_after_start()
        {
            var expected = vector(3, 4, 5, 6, 7);
            var actual = subVec(vector(1, 2, 3, 4, 5, 6, 7), 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubVec_should_return_all_items_after_start_but_before_end()
        {
            var expected = vector(3, 4);
            var actual = subVec(vector(1, 2, 3, 4, 5, 6, 7), 2, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}

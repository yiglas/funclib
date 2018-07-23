using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ButLastShould
    {
        [Test]
        public void ButLast_should_return_all_but_last_item()
        {
            var expected = vector(1, 2);
            var actual = butLast(vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ButLast_should_return_null_if_empty_list_passed()
        {
            var actual = butLast(vector());

            Assert.IsNull(actual);
        }

        [Test]
        public void ButLast_should_return_null_if_passed_null()
        {
            var actual = butLast(null);

            Assert.IsNull(actual);
        }
    }
}

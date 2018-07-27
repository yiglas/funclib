using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IdentityShould
    {
        [Test]
        public void Identity_should_return_its_argument()
        {
            var expected = 4;
            var actual = identity(4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Identity_should_filter_out_falsy_values()
        {
            var expected = list(1, 2, 3, 4, true, 1234);
            var actual = toArray(filter(new Identity(), vector(1, 2, 3, null, 4, false, true, 1234)));

            Assert.AreEqual(expected, actual);
        }
    }
}

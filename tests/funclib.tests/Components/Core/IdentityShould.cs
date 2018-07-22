using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IdentityShould
    {
        [Test]
        public void Identity_should_return_its_argument()
        {
            var expected = 4;
            var actual = new Identity().Invoke(4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Identity_should_filter_out_falsy_values()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 2, 3, 4, true, 1234);
            var actual = new ToArray().Invoke(filter(new Identity(), new Vector().Invoke(1, 2, 3, null, 4, false, true, 1234)));

            Assert.AreEqual(expected, actual);
        }
    }
}

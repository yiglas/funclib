using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IdentityShould
    {
        [Test]
        public void Identity_should_return_its_argument()
        {
            var expected = 4;
            var actual = funclib.Core.Identity(4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Identity_should_filter_out_falsy_values()
        {
            var expected = funclib.Core.List(1, 2, 3, 4, true, 1234);
            var actual = funclib.Core.ToArray(funclib.Core.Filter(new Identity(), funclib.Core.Vector(1, 2, 3, null, 4, false, true, 1234)));

            Assert.AreEqual(expected, actual);
        }
    }
}

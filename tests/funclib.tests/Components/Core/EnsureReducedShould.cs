using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class EnsureReducedShould
    {
        [Test]
        public void EnsureReduced_should_return_the_value_wrapped()
        {
            var actual = funclib.Core.EnsureReduced(1);

            Assert.IsInstanceOf<Reduced>(actual);
        }

        [Test]
        public void EnsureReduced_should_return_the_deref_value_if_its_reduced()
        {
            var expected = funclib.Core.Reduced(1);
            var actual = funclib.Core.EnsureReduced(expected);

            Assert.IsTrue(expected == actual);
        }
    }
}

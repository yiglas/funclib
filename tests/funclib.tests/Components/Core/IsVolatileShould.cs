using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsVolatileShould
    {
        [Test]
        public void IsVolatile_should_return_true_if_volatile()
        {
            Assert.IsTrue((bool)funclib.Core.IsVolatile(funclib.Core.Volatileǃ("foo")));
        }

        [Test]
        public void IsVolatile_should_return_false_if_not_volatile()
        {
            Assert.IsFalse((bool)funclib.Core.IsVolatile(0));
        }
    }
}

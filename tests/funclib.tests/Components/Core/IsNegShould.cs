using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsNegShould
    {
        [Test]
        public void IsNeg_should_return_true_if_an_object_is_less_than_zero()
        {
            Assert.IsTrue((bool)funclib.Core.IsNeg(-1));
        }

        [Test]
        public void IsNeg_should_return_false_if_an_object_is_not_less_than_zero()
        {
            Assert.IsFalse((bool)funclib.Core.IsNeg(1));
            Assert.IsFalse((bool)funclib.Core.IsNeg(0));
        }
    }
}

using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsNegIntShould
    {
        [Test]
        public void IsNegInt_should_return_true_if_an_object_is_negative_int()
        {
            Assert.IsTrue((bool)funclib.Core.IsNegInt(-1));
        }

        [Test]
        public void IsNegInt_should_return_false_if_an_object_is_not_negative_int()
        {
            Assert.IsFalse((bool)funclib.Core.IsNegInt(1));
            Assert.IsFalse((bool)funclib.Core.IsNegInt(null));
            Assert.IsFalse((bool)funclib.Core.IsNegInt(0));
            Assert.IsFalse((bool)funclib.Core.IsNegInt((double)-1));
        }
    }
}

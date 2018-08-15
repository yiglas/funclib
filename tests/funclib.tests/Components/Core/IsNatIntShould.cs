using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsNatIntShould
    {
        [Test]
        public void IsNatInt_should_return_true_if_an_object_is_NonNegative()
        {
            Assert.IsTrue((bool)funclib.Core.IsNatInt(1));
            Assert.IsTrue((bool)funclib.Core.IsNatInt(0));
        }

        [Test]
        public void IsNatInt_should_return_false_if_an_object_is_not_NonNegative()
        {
            Assert.IsFalse((bool)funclib.Core.IsNatInt(-1));
            Assert.IsFalse((bool)funclib.Core.IsNatInt(null));
        }
    }
}

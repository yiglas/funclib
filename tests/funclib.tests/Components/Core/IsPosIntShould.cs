using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsPosIntShould
    {
        [Test]
        public void IsPosInt_should_return_true_if_is_a_positive_int()
        {
            Assert.IsTrue((bool)funclib.Core.IsPosInt(1));
        }

        [Test]
        public void IsPosInt_should_return_false_if_is_not_a_positive_int()
        {
            Assert.IsFalse((bool)funclib.Core.IsPosInt(0));
            Assert.IsFalse((bool)funclib.Core.IsPosInt((double)1));
            Assert.IsFalse((bool)funclib.Core.IsPosInt(-1));
        }
    }
}

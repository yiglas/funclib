using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsFalseShould
    {
        [Test]
        public void IsFalse_should_return_true_if_an_object_is_false()
        {
            Assert.IsTrue((bool)funclib.Core.IsFalse(false));
        }

        [Test]
        public void IsFalse_should_return_false_if_an_object_is_not_false()
        {
            Assert.IsFalse((bool)funclib.Core.IsFalse(1));
            Assert.IsFalse((bool)funclib.Core.IsFalse(null));
            Assert.IsFalse((bool)funclib.Core.IsFalse(true));
        }
    }
}

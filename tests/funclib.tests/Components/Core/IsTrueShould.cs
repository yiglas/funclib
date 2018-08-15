using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsTrueShould
    {
        [Test]
        public void IsTrue_should_return_true_if_an_object_is_True()
        {
            Assert.IsTrue((bool)funclib.Core.IsTrue(true));
            Assert.IsTrue((bool)funclib.Core.IsTrue(1 == 1));
        }

        [Test]
        public void IsTrue_should_return_True_if_an_object_is_not_True()
        {
            Assert.IsFalse((bool)funclib.Core.IsTrue(1));
            Assert.IsFalse((bool)funclib.Core.IsTrue(null));
            Assert.IsFalse((bool)funclib.Core.IsTrue(false));
        }
    }
}

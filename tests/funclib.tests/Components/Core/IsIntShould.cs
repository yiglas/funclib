using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsIntShould
    {
        [Test]
        public void IsInt_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)funclib.Core.IsInt(1));
            Assert.IsTrue((bool)funclib.Core.IsInt((short)1));
            Assert.IsTrue((bool)funclib.Core.IsInt((long)1));
            Assert.IsTrue((bool)funclib.Core.IsInt((byte)1));
        }

        [Test]
        public void IsInt_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)funclib.Core.IsInt((double)1));
            Assert.IsFalse((bool)funclib.Core.IsInt(null));
        }
    }
}

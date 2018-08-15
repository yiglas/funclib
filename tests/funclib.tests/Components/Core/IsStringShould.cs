using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsStringShould
    {
        [Test]
        public void IsString_should_return_true_if_x_is_string()
        {
            Assert.IsTrue((bool)funclib.Core.IsString("abc"));
            Assert.IsTrue((bool)funclib.Core.IsString(""));
        }

        [Test]
        public void IsString_should_return_false_if_x_is_not_string()
        {
            Assert.IsFalse((bool)funclib.Core.IsString(funclib.Core.Vector("1", "2", "3")));
            Assert.IsFalse((bool)funclib.Core.IsString('a'));
            Assert.IsFalse((bool)funclib.Core.IsString(null));
            Assert.IsFalse((bool)funclib.Core.IsString(1));
        }
    }
}

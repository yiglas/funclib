using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsCharShould
    {
        [Test]
        public void IsChar_should_return_true_if_an_object_is_a_char()
        {
            Assert.IsTrue((bool)funclib.Core.IsChar('c'));

            object b = 'c';
            Assert.IsTrue((bool)funclib.Core.IsChar(b));
        }

        [Test]
        public void IsChar_should_return_false_if_an_object_is_not_a_char()
        {
            Assert.IsFalse((bool)funclib.Core.IsChar(1));
            Assert.IsFalse((bool)funclib.Core.IsChar(null));
        }
    }
}
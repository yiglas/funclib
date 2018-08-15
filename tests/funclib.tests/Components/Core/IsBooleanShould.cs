using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsBooleanShould
    {
        [Test]
        public void IsBoolean_should_return_true_if_an_object_is_a_boolean()
        {
            Assert.IsTrue((bool)funclib.Core.IsBoolean(true));
            Assert.IsTrue((bool)funclib.Core.IsBoolean(false));

            object b = true;
            Assert.IsTrue((bool)funclib.Core.IsBoolean(b));
        }

        [Test]
        public void IsBoolean_should_return_false_if_an_object_is_not_a_boolean()
        {
            Assert.IsFalse((bool)funclib.Core.IsBoolean(1));
            Assert.IsFalse((bool)funclib.Core.IsBoolean(null));
        }
    }
}
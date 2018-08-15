using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsFunctionShould
    {
        [Test]
        public void IsFunction_should_return_true_if_an_object_is_IFunction()
        {
            Assert.IsTrue((bool)funclib.Core.IsFunction(new Vector()));
        }

        [Test]
        public void IsFunction_should_return_false_if_an_object_is_not_IFunction()
        {
            Assert.IsFalse((bool)funclib.Core.IsFunction(1));
            Assert.IsFalse((bool)funclib.Core.IsFunction(null));
        }
    }
}

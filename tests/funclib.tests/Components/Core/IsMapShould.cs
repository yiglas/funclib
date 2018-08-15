using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsMapShould
    {
        [Test]
        public void IsMap_should_return_true_if_an_object_is_IMap()
        {
            Assert.IsTrue((bool)funclib.Core.IsMap(funclib.Core.HashMap()));
        }

        [Test]
        public void IsMap_should_return_false_if_an_object_is_not_IMap()
        {
            Assert.IsFalse((bool)funclib.Core.IsMap(1));
            Assert.IsFalse((bool)funclib.Core.IsMap(null));
        }
    }
}

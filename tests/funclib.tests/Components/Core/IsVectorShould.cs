using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsVectorShould
    {
        [Test]
        public void IsVector_should_return_true_if_an_object_is_false()
        {
            Assert.IsTrue((bool)funclib.Core.IsVector(funclib.Core.Vector(1, 2, 3)));
            Assert.IsTrue((bool)funclib.Core.IsVector(funclib.Core.Vec(new object[] { 1, 2, 3 })));
            Assert.IsTrue((bool)funclib.Core.IsVector(funclib.Core.First(funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3))));
        }

        [Test]
        public void IsVector_should_return_false_if_an_object_is_not_false()
        {
            Assert.IsFalse((bool)funclib.Core.IsVector(1));
            Assert.IsFalse((bool)funclib.Core.IsVector(null));
            Assert.IsFalse((bool)funclib.Core.IsVector(funclib.Core.HashSet(1, 2, 3)));
        }
    }
}

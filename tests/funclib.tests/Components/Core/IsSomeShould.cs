using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsSomeShould
    {
        [Test]
        public void IsSome_should_return_true_if_not_null()
        {
            Assert.IsTrue((bool)funclib.Core.IsSome(1));
            Assert.IsTrue((bool)funclib.Core.IsSome(false));
            Assert.IsTrue((bool)funclib.Core.IsSome(funclib.Core.Vector(1, 2, 3)));
        }

        [Test]
        public void IsSome_should_return_false_if_is_null()
        {
            Assert.IsFalse((bool)funclib.Core.IsSome(null));
        }
    }
}

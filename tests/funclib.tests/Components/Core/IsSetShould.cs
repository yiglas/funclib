using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsSetShould
    {
        [Test]
        public void IsSet_should_return_true_if_reduced()
        {
            Assert.IsTrue((bool)funclib.Core.IsSet(funclib.Core.HashSet(1, 2, 3)));
            Assert.IsTrue((bool)funclib.Core.IsSet(funclib.Core.SortedSet(1, 2, 3)));
        }

        [Test]
        public void IsSet_should_return_false_if_not_reduced()
        {
            Assert.IsFalse((bool)funclib.Core.IsSet(funclib.Core.Vector(1, 2, 3)));
        }
    }
}

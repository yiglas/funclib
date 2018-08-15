using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsSortedShould
    {
        [Test]
        public void IsSorted_should_return_true_if_implements_sorted()
        {
            Assert.IsTrue((bool)funclib.Core.IsSorted(funclib.Core.SortedSet(1, 2, 3)));
        }

        [Test]
        public void IsSorted_should_return_false_if_doesnot_implements_sorted()
        {
            Assert.IsFalse((bool)funclib.Core.IsSorted(funclib.Core.Vector(1, 2, 3)));
        }
    }
}

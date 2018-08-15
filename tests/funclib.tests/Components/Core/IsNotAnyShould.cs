using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsNotAnyShould
    {
        [Test]
        public void IsNotAny_should_return_true_if_a_collection_does_not_contain_odd()
        {
            Assert.IsTrue((bool)funclib.Core.IsNotAny(new IsOdd(), funclib.Core.List(2, 4, 6)));
        }

        [Test]
        public void IsCounted_should_return_false_if_a_collection_does_contain_odd()
        {
            Assert.IsFalse((bool)funclib.Core.IsNotAny(new IsOdd(), funclib.Core.List(1, 2, 3)));
            Assert.IsFalse((bool)funclib.Core.IsNotAny(new IsOdd(), funclib.Core.List(1, 2, 4)));
        }
    }
}

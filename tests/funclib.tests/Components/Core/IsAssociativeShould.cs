using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsAssociativeShould
    {
        [Test]
        public void IsAssociative_should_return_true_if_an_object_that_implements_IAssociative()
        {
            Assert.IsTrue((bool)funclib.Core.IsAssociative(funclib.Core.HashMap()));
            Assert.IsTrue((bool)funclib.Core.IsAssociative(funclib.Core.ArrayMap()));
        }

        [Test]
        public void IsAssociative_should_return_false_if_an_object_doesnot_implement_IAssociative()
        {
            Assert.IsFalse((bool)funclib.Core.IsAssociative(1));
            Assert.IsFalse((bool)funclib.Core.IsAssociative(null));
        }
    }
}
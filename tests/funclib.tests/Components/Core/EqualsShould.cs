using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class EqualsShould
    {
        [Test]
        public void Equals_should_always_return_true_if_passed_a_single_value()
        {
            var actual = funclib.Core.IsEqualTo(false);

            Assert.IsTrue((bool)actual);
        }

        [Test]
        public void Equals_should_test_equality_between_two_objects()
        {
            Assert.IsTrue((bool)funclib.Core.IsEqualTo(1, 1));
            Assert.IsTrue((bool)funclib.Core.IsEqualTo(funclib.Core.Vector(1, 2), funclib.Core.Vector(1, 2)));
            Assert.IsFalse((bool)funclib.Core.IsEqualTo(1, "1"));
            Assert.IsFalse((bool)funclib.Core.IsEqualTo(null, 1));
        }

        [Test]
        public void Equals_should_test_equality_with_unlimited_number_of_objects()
        {
            Assert.IsTrue((bool)funclib.Core.IsEqualTo(1, 1, 1, 1));
            Assert.IsTrue((bool)funclib.Core.IsEqualTo(funclib.Core.Vector(1, 2), funclib.Core.Vector(1, 2), funclib.Core.Vector(1, 2)));
            Assert.IsFalse((bool)funclib.Core.IsEqualTo(1, 1, "1"));
            Assert.IsFalse((bool)funclib.Core.IsEqualTo(null, 1, 1, 1));
        }
    }
}

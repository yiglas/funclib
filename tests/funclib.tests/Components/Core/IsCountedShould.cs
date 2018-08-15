using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsCountedShould
    {
        [Test]
        public void IsCounted_should_return_true_if_an_object_is_ICounted()
        {
            Assert.IsTrue((bool)funclib.Core.IsCounted(funclib.Core.Vector()));
        }

        [Test]
        public void IsCounted_should_return_false_if_an_object_is_not_ICounted()
        {
            Assert.IsFalse((bool)funclib.Core.IsCounted(1));
            Assert.IsFalse((bool)funclib.Core.IsCounted(null));
        }
    }
}
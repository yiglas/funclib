using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsListShould
    {
        [Test]
        public void IsList_should_return_true_if_an_object_is_IList()
        {
            Assert.IsTrue((bool)funclib.Core.IsList(funclib.Core.List()));
        }

        [Test]
        public void IsList_should_return_false_if_an_object_is_not_IList()
        {
            Assert.IsFalse((bool)funclib.Core.IsList(funclib.Core.Vector()));
            Assert.IsFalse((bool)funclib.Core.IsList(null));
        }
    }
}

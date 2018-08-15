using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class BooleanShould
    {
        [Test]
        public void Boolean_should_return_value_of_boolean()
        {
            Assert.IsTrue((bool)new funclib.Components.Core.Boolean().Invoke(true));
            Assert.IsFalse((bool)new funclib.Components.Core.Boolean().Invoke(false));
        }

        [Test]
        public void Boolean_should_return_false_if_passed_null_object()
        {
            Assert.IsFalse((bool)new funclib.Components.Core.Boolean().Invoke(null));
        }

        [Test]
        public void Boolean_should_return_true_if_passed_non_null_object()
        {
            Assert.IsTrue((bool)new funclib.Components.Core.Boolean().Invoke(1));
        }
    }
}

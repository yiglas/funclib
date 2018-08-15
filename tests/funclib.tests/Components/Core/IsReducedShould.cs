using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsReducedShould
    {
        [Test]
        public void IsReduced_should_return_true_if_reduced()
        {
            Assert.IsTrue((bool)funclib.Core.IsReduced(funclib.Core.Reduced("foo")));
        }

        [Test]
        public void IsReduced_should_return_false_if_not_reduced()
        {
            Assert.IsFalse((bool)funclib.Core.IsReduced(0));
        }
    }
}

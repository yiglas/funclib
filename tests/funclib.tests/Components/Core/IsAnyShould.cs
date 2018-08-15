using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsAnyShould
    {
        [Test]
        public void IsAny_should_return_true_given_any_argument()
        {
            Assert.IsTrue((bool)funclib.Core.IsAny(1));
            Assert.IsTrue((bool)funclib.Core.IsAny(null));
        }
    }
}

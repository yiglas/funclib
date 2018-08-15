using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DerefShould
    {
        [Test]
        public void Deref_should_return_the_current_state_of_ref()
        {
            var expected = 10;
            var r = funclib.Core.Reduced(expected);
            var actual = funclib.Core.Deref(r);

            Assert.AreEqual(expected, actual);
        }
    }
}

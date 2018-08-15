using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SubsShould
    {
        [Test]
        public void Subs_should_return_string_after_start()
        {
            var expected = "net core";
            var actual = funclib.Core.Subs(".net core", 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Subs_should_return_string_before_start_end()
        {
            var expected = "ne";
            var actual = funclib.Core.Subs(".net core", 1, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}

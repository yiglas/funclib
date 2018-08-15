using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReFindShould
    {
        [Test]
        public void ReFind_should_return_first_match_when_called_once()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = funclib.Core.ReMatcher(funclib.Core.RePattern(@"\d+"), phoneNumber);

            var expected = "123";
            var actual = funclib.Core.ReFind(matcher);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refind_should_return_second_match_when_called_twice()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = funclib.Core.ReMatcher(funclib.Core.RePattern(@"\d+"), phoneNumber);

            var expected = "456";
            funclib.Core.ReFind(matcher);
            var actual = funclib.Core.ReFind(matcher);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refind_should_return_null_when_matches_have_been_exausted()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = funclib.Core.ReMatcher(funclib.Core.RePattern(@"\d+"), phoneNumber);

            funclib.Core.ReFind(matcher);
            funclib.Core.ReFind(matcher);
            funclib.Core.ReFind(matcher);
            funclib.Core.ReFind(matcher);
            var actual = funclib.Core.ReFind(matcher);

            Assert.IsNull(actual);
        }

        [Test]
        public void ReFind_should_allow_a_string_for_its_pattern()
        {
            var phoneNumber = "123-456-789-1234";
            
            var expected = "123";
            var actual = funclib.Core.ReFind(funclib.Core.RePattern(@"\d+"), phoneNumber);

            Assert.AreEqual(expected, actual);
        }

    }
}

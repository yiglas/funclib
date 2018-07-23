using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReFindShould
    {
        [Test]
        public void ReFind_should_return_first_match_when_called_once()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = reMatcher(rePattern(@"\d+"), phoneNumber);

            var expected = "123";
            var actual = reFind(matcher);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refind_should_return_second_match_when_called_twice()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = reMatcher(rePattern(@"\d+"), phoneNumber);

            var expected = "456";
            reFind(matcher);
            var actual = reFind(matcher);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refind_should_return_null_when_matches_have_been_exausted()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = reMatcher(rePattern(@"\d+"), phoneNumber);

            reFind(matcher);
            reFind(matcher);
            reFind(matcher);
            reFind(matcher);
            var actual = reFind(matcher);

            Assert.IsNull(actual);
        }

        [Test]
        public void ReFind_should_allow_a_string_for_its_pattern()
        {
            var phoneNumber = "123-456-789-1234";
            
            var expected = "123";
            var actual = reFind(rePattern(@"\d+"), phoneNumber);

            Assert.AreEqual(expected, actual);
        }

    }
}

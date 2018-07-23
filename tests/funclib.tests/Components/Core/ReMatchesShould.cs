using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReMatchesShould
    {
        [Test]
        public void ReMatches_should_match_entire_string_and_return_null_if_not_matched()
        {
            var actual = reMatches(rePattern(@"hello"), "hello, world");

            Assert.IsNull(actual);
        }

        [Test]
        public void ReMatches_should_match_entire_string()
        {
            var expected = "hello, world";
            var actual = reMatches(rePattern(@"hello.*"), "hello, world");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rematches_should_return_a_vector_when_groups_are_uses()
        {
            var expected = vector("hello, world", "world");
            var actual = reMatches(rePattern(@"hello, (.*)"), "hello, world");

            Assert.AreEqual(expected, actual);
        }
    }
}

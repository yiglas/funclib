using funclib.Collections.Generic;
using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace funclib.Tests.Collections.Generic
{
    public class EnumeratorSeqShould
    {
        [Test]
        public void EnumeratorSeq_should_match_array()
        {
            var expected = new[] { "exciting", "example" };
            var actual = EnumeratorSeq<string>.Create("exciting example".Split(new[] { ' ' }).ToList().GetEnumerator());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnumeratorSeq_should_return_null_if_passed_a_completed_enumerator()
        {
            var actual = EnumeratorSeq<char>.Create("".ToList().GetEnumerator());

            Assert.IsNull(actual);
        }
    }
}
using funclib.Collections;
using NUnit.Framework;
using System.Linq;

namespace funclib.Tests.Collections
{
    public class EnumeratorSeqShould
    {
        [Test]
        public void Test()
        {
            var expected = new[] { "exciting", "example" };
            var actual = EnumeratorSeq.Create("exciting example".Split(new[] { ' ' }).GetEnumerator());

            Assert.AreEqual(expected, actual);
        }
    }
}
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class RSeqShould
    {
        [Test]
        public void RSeq_should_reverse_a_vector()
        {
            var expected = funclib.Core.List(9, 8, 7, 6, 5, 4, 3, 2, 1, 0);
            var actual = funclib.Core.RSeq(funclib.Core.Vec(funclib.Core.Range(10)));

            Assert.AreEqual(expected, actual);
        }
    }
}

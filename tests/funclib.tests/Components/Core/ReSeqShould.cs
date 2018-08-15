using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReSeqShould
    {
        [Test]
        public void ReSeq_should_return_a_lazyseq()
        {
            var actual = funclib.Core.ReSeq(funclib.Core.RePattern(@"\d"), ".NET 1.1.1");

            Assert.IsInstanceOf<funclib.Collections.Cons>(actual);
        }
    }
}

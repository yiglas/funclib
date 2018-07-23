using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReSeqShould
    {
        [Test]
        public void ReSeq_should_return_a_lazyseq()
        {
            var actual = reSeq(rePattern(@"\d"), ".NET 1.1.1");

            Assert.IsInstanceOf<funclib.Collections.Cons>(actual);
        }
    }
}

using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsSeqShould
    {
        [Test]
        public void IsSeq_should_return_true_if_ISeq()
        {
            Assert.IsTrue((bool)new IsSeq().Invoke(new Seq().Invoke(new Vector().Invoke(1))));
            Assert.IsTrue((bool)new IsSeq().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3)));
            Assert.IsTrue((bool)new IsSeq().Invoke(new Seq().Invoke(new Range().Invoke(1, 5))));
        }

        [Test]
        public void IsSeq_should_return_false_if_not_ISeq()
        {
            Assert.IsFalse((bool)new IsSeq().Invoke(1));
            Assert.IsFalse((bool)new IsSeq().Invoke(new Vector().Invoke(1)));
            Assert.IsFalse((bool)new IsSeq().Invoke(new HashMap().Invoke(":a", 1, ":b", 2)));
        }
    }
}

using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsSeqableShould
    {
        [Test]
        public void IsSeqable_should_return_true_if_object_is_seqable()
        {
            Assert.IsTrue((bool)new IsSeqable().Invoke(null));
            Assert.IsTrue((bool)new IsSeqable().Invoke(""));
            Assert.IsTrue((bool)new IsSeqable().Invoke(new System.Collections.Generic.List<string>()));
            Assert.IsTrue((bool)new IsSeqable().Invoke(new Vector().Invoke()));
            Assert.IsTrue((bool)new IsSeqable().Invoke(new LazySeq()));
        }

        [Test]
        public void IsSeqable_should_return_false_if_not_object_is_seqable()
        {
            Assert.IsFalse((bool)isReduced(0));
        }
    }
}

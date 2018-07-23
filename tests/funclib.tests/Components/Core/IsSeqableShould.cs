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
            Assert.IsTrue((bool)isSeqable(null));
            Assert.IsTrue((bool)isSeqable(""));
            Assert.IsTrue((bool)isSeqable(new System.Collections.Generic.List<string>()));
            Assert.IsTrue((bool)isSeqable(new Vector().Invoke()));
            Assert.IsTrue((bool)isSeqable(lazySeq()));
        }

        [Test]
        public void IsSeqable_should_return_false_if_not_object_is_seqable()
        {
            Assert.IsFalse((bool)isReduced(0));
        }
    }
}

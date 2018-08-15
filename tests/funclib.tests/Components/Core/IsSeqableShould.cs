using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsSeqableShould
    {
        [Test]
        public void IsSeqable_should_return_true_if_object_is_seqable()
        {
            Assert.IsTrue((bool)funclib.Core.IsSeqable(null));
            Assert.IsTrue((bool)funclib.Core.IsSeqable(""));
            Assert.IsTrue((bool)funclib.Core.IsSeqable(new System.Collections.Generic.List<string>()));
            Assert.IsTrue((bool)funclib.Core.IsSeqable(funclib.Core.Vector()));
            Assert.IsTrue((bool)funclib.Core.IsSeqable(funclib.Core.LazySeq()));
        }

        [Test]
        public void IsSeqable_should_return_false_if_not_object_is_seqable()
        {
            Assert.IsFalse((bool)funclib.Core.IsSeqable(0));
        }
    }
}

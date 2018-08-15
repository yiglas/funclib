using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsSeqShould
    {
        [Test]
        public void IsSeq_should_return_true_if_ISeq()
        {
            Assert.IsTrue((bool)funclib.Core.IsSeq(funclib.Core.Seq(funclib.Core.Vector(1))));
            Assert.IsTrue((bool)funclib.Core.IsSeq(funclib.Core.List(1, 2, 3)));
            Assert.IsTrue((bool)funclib.Core.IsSeq(funclib.Core.Seq(funclib.Core.Range(1, 5))));
        }

        [Test]
        public void IsSeq_should_return_false_if_not_ISeq()
        {
            Assert.IsFalse((bool)funclib.Core.IsSeq(1));
            Assert.IsFalse((bool)funclib.Core.IsSeq(funclib.Core.Vector(1)));
            Assert.IsFalse((bool)funclib.Core.IsSeq(funclib.Core.HashMap(":a", 1, ":b", 2)));
        }
    }
}

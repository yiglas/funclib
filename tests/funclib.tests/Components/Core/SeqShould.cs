using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SeqShould
    {
        [Test]
        public void Seq_should_return_null_when_passed_an_empty_list()
        {
            Assert.IsNull(funclib.Core.Seq(funclib.Core.Vector()));
            Assert.IsNull(funclib.Core.Seq(funclib.Core.HashSet()));
            Assert.IsNull(funclib.Core.Seq(funclib.Core.List()));
        }

        [Test]
        public void Seq_should_return_char_array_when_passed_a_string()
        {
            var actual = (funclib.Collections.ISeq)funclib.Core.Seq("abc");

            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void Seq_should_return_null_if_passed()
        {
            Assert.IsNull(funclib.Core.Seq(null));
            Assert.IsNull(funclib.Core.Seq(""));
        }
    }
}

using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SeqShould
    {
        [Test]
        public void Seq_should_return_null_when_passed_an_empty_list()
        {
            Assert.IsNull(seq(vector()));
            Assert.IsNull(seq(hashSet()));
            Assert.IsNull(seq(list()));
        }

        [Test]
        public void Seq_should_return_char_array_when_passed_a_string()
        {
            var actual = (funclib.Collections.ISeq)seq("abc");

            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void Seq_should_return_null_if_passed()
        {
            Assert.IsNull(seq(null));
            Assert.IsNull(seq(""));
        }
    }
}

using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;
using FunctionalLibrary.Collections;

namespace FunctionalLibrary.Tests.Core
{
    public class SeqShould
    {
        [Test]
        public void Seq_should_return_null_when_passed_an_empty_list()
        {
            var actual = new Seq().Invoke(FunctionalLibrary.Collections.List.EMPTY);

            Assert.IsNull(actual);
        }

        [Test]
        public void Seq_should_return_char_array_when_passed_a_string()
        {
            var actual = (ISeq)new Seq().Invoke("abc");

            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void Seq_should_return_null_if_passed()
        {
            Assert.IsNull(new Seq().Invoke(null));
            Assert.IsNull(new Seq().Invoke(""));
        }
    }
}

using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class SeqShould
    {
        [Test]
        public void Seq_should_return_null_when_passed_an_empty_list()
        {
            Assert.IsNull(new Seq().Invoke(new Vector().Invoke()));
            Assert.IsNull(new Seq().Invoke(new HashSet().Invoke()));
            Assert.IsNull(new Seq().Invoke(new funclib.Components.Core.List().Invoke()));
        }

        [Test]
        public void Seq_should_return_char_array_when_passed_a_string()
        {
            var actual = (funclib.Collections.ISeq)new Seq().Invoke("abc");

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

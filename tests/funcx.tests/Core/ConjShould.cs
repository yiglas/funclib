using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ConjShould
    {
        [Test]
        public void Conj_should_add_to_end_of_vector()
        {
            var expected = new Vector().Invoke(1, 2);
            var actual = new Conj().Invoke(new Vector().Invoke(1), 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Conj_should_add_one_item_to_a_vector()
        {
            var expected = new Vector().Invoke(1);
            var actual = new Conj().Invoke(new Vector().Invoke(), 1);

            Assert.AreEqual(expected, actual);
        }

    }
}

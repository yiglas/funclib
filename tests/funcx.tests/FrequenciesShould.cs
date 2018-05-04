using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class FrequenciesShould
    {
        [Test]
        public void Frequencies_should_return_a_dictionary_with_the_key_as_the_unique_item_and_value_the_count()
        {
            var actual = frequencies(new string[] { "a", "a", "a", "b", "b" });

            Assert.AreEqual(3, actual["a"]);
            Assert.AreEqual(2, actual["b"]);
        }
    }
}

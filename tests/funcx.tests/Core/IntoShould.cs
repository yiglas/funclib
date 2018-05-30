using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
{
    public class IntoShould
    {
        [Test]
        public void Into_should_return_an_empty_list_if_null_is_passed()
        {
            var actual = into<string>(null, null);

            Assert.AreEqual(actual.GetType(), typeof(List<string>));
        }

        [Test]
        public void Into_should_return_a_list_of_key_value_pairs_if_passed_dictionary()
        {
            var actual = into(null, new Dictionary<int, string>() { [1] = "a" });

            Assert.AreEqual(actual.GetType(), typeof(Dictionary<int, string>));
        }

        [Test]
        public void Into_should_return_a_new_collection_with_from_reversed_and_at_the_beginning_to_at_the_end()
        {
            var actual = into(new List<string>(){ "a", "b", "c" }, new List<string>() { "d", "e", "f" }) as List<string>;

            Assert.AreEqual(actual[0], "f");
            Assert.AreEqual(actual[5], "c");
        }

        [Test]
        public void Into_should_return_a_new_collection_of_two_when_null_is_passed_for_from()
        {
            var actual = into(new Dictionary<int, string>() { [2] = "b" }, null) as Dictionary<int, string>;
            
            Assert.AreEqual(actual[2], "b");
        }
    }
}

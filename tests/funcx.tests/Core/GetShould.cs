using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
{
    public class GetShould
    {
        [Test]
        public void Get_should_find_a_value_from_a_dictionary()
        {
            var actual = get(new Dictionary<string, int>() { ["a"] = 1 }, "a");

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Get_should_return_the_missing_param_if_it_cannot_find_the_value()
        {
            var actual = get(new Dictionary<string, int>() { ["a"] = 1 }, "b", 2);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Get_should_find_a_value_at_an_index_for_an_array()
        {
            var actual = get(new List<string>(){ "a", "b" }, 1);

            Assert.AreEqual("b", actual);
        }

        [Test]
        public void Get_should_return_the_missing_param_if_its_index_is_out_of_bounds()
        {
            var actual = get(new List<string>() { "a", "b" }, 2, "missing");

            Assert.AreEqual("missing", actual);
        }
    }
}

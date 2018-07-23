using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ApplyShould
    {
        [Test]
        public void Apply_should_apply_each_item_in_array_to_the_function()
        {
            var expected = "str1str2str3";
            var actual = apply(new Str(), vector("str1", "str2", "str3"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_apply_each_item_to_function_with_x_being_its_first_arg()
        {
            var expected = "str1str2str3";
            var actual = apply(new Str(), "str1", vector("str2", "str3"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_beable_to_check_max_on_array()
        {
            var expected = 3;
            var actual = apply(new Max(), 1, 2, vector(3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_allow_function_with_no_parameters_to_be_executed()
        {
            var actual = (bool)apply(new And(), null);

            Assert.IsTrue(actual);
        }
    }
}

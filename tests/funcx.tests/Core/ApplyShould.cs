using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ApplyShould
    {
        [Test]
        public void Apply_should_apply_each_item_in_array_to_the_function()
        {
            var expected = "str1str2str3";
            var actual = new Apply().Invoke(new Str(), new Vector().Invoke("str1", "str2", "str3"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_apply_each_item_to_function_with_x_being_its_first_arg()
        {
            var expected = "str1str2str3";
            var actual = new Apply().Invoke(new Str(), "str1", new Vector().Invoke("str2", "str3"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_beable_to_check_max_on_array()
        {
            var expected = 3;
            var actual = new Apply().Invoke(new Max(), 1, 2, new Vector().Invoke(3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Apply_should_allow_function_with_no_parameters_to_be_executed()
        {
            var actual = (bool)new Apply().Invoke(new And(), null);

            Assert.IsTrue(actual);
        }
    }
}

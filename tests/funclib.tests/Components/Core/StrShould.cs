using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class StrShould
    {
        [Test]
        public void Str_should_return_empty_string_if_not_params_passed()
        {
            var expected = "";
            var actual = str();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Str_should_return_empty_string_if_passed_null_value()
        {
            var expected = "";
            var actual = str(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Str_should_return_string_value_of_object_passed()
        {
            var expected = "1";
            var actual = str(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Str_should_concat_all_values_passed_into_one_string()
        {
            var expected = "1symbolTrue";
            var actual = str(1, "symbol", true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Str_should_call_to_string_on_objects()
        {
            var expected = "[1 2 3]";
            var actual = str(vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Str_should_apply_str_to_all_params_returning_one_large_str()
        {
            var expected = "123456789";
            var actual = str(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(expected, actual);
        }
    }
}

using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PlusShould
    {
        [Test]
        public void Plus_should_return_zero_when_passed_no_paramters()
        {
            var expected = 0;
            var actual = plus();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_return_passed_in_number_when_one_parameter_is_passed()
        {
            var expected = 2;
            var actual = plus(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_throw_an_exception_if_not_passed_a_number()
        {
            Assert.Throws<InvalidCastException>(() => plus(""));
        }

        [Test]
        public void Plus_should_add_passed_in_numbers()
        {
            var expected = 4;
            var actual = plus(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_add_all_passing_mulitple_items()
        {
            var expected = 10;
            var actual = plus(1, 2, 3, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}

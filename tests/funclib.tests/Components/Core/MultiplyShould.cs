using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class MultiplyShould
    {
        [Test]
        public void Multiply_should_return_zero_when_passed_no_paramters()
        {
            var expected = 0;
            var actual = new Multiply().Invoke();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_should_return_passed_in_number_when_one_parameter_is_passed()
        {
            var expected = 2;
            var actual = new Multiply().Invoke(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_should_throw_an_exception_if_not_passed_a_number()
        {
            Assert.Throws<InvalidCastException>(() => new Multiply().Invoke(""));
        }

        [Test]
        public void Multiply_should_multiply_passed_in_numbers()
        {
            var expected = 4;
            var actual = new Multiply().Invoke(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_should_multiply_all_passing_mulitple_items()
        {
            var expected = 24;
            var actual = new Multiply().Invoke(1, 2, 3, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}

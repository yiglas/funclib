using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class PlusShould
    {
        [Test]
        public void Plus_should_return_one_when_passed_no_paramters()
        {
            var expected = 1;
            var actual = new Plus().Invoke();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_return_passed_in_number_when_one_parameter_is_passed()
        {
            var expected = 2;
            var actual = new Plus().Invoke(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_throw_an_exception_if_not_passed_a_number()
        {
            Assert.Throws<InvalidCastException>(() => new Plus().Invoke(""));
        }

        [Test]
        public void Plus_should_add_passed_in_numbers()
        {
            var expected = 4;
            var actual = new Plus().Invoke(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Plus_should_add_all_passing_mulitple_items()
        {
            var expected = 10;
            var actual = new Plus().Invoke(1, 2, 3, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}

using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class AssocShould
    {
        [Test]
        public void Assoc_should_add_item_params_to_an_empty_map()
        {
            var expected = new HashMap().Invoke(":key1", "value", ":key2", "another value", ":key3", "value3");
            var actual = new Assoc().Invoke(new HashMap().Invoke(), ":key1", "value", ":key2", "another value", ":key3", "value3");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_add_items_params_to_a_map()
        {
            var expected = new HashMap().Invoke(":key3", "value3", ":key2", "value2", ":key1", "value1");

            var actual = new Assoc().Invoke(new HashMap().Invoke(":key1", "old value1", ":key2", "value2"), ":key1", "value1", ":key3", "value3");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_throw_exception_when_passing_an_odd_number_of_params()
        {
            Assert.Throws<ArgumentException>(() => new Assoc().Invoke(new HashMap().Invoke(), ":key1", "value1", ":key3"));
        }

        [Test]
        public void Assoc_should_allow_passing_null_as_the_map_and_its_return_is_ArrayMap()
        {
            var expected = new ArrayMap().Invoke(1, 2);
            var actual = new Assoc().Invoke(null, 1, 2);

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<FunctionalLibrary.Collections.ArrayMap>(actual);
        }

        [Test]
        public void Assoc_should_allow_vectors_as_well()
        {
            var expected = new Vector().Invoke(10, 2, 3);
            var actual = new Assoc().Invoke(new Vector().Invoke(1, 2, 3), 0, 10);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_throw_exception_if_adding_vector_out_of_bounds()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Assoc().Invoke(new Vector().Invoke(1, 2, 3), 4, 10));
        }

        [Test]
        public void Assoc_should_add_item_to_vector()
        {
            var expected = new Vector().Invoke(1, 2, 3, 10);
            var actual = new Assoc().Invoke(new Vector().Invoke(1, 2, 3), 3, 10);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_not_modify_starting_map()
        {
            var expected = new HashMap().Invoke(":account-no", 12345678, ":lname", "Jones", ":fname", "Fred");
            var actual = new Assoc().Invoke(expected, ":fname", "Sue");

            Assert.AreNotEqual(expected, actual);
        }
    }
}

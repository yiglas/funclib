using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ConjShould
    {
        [Test]
        public void Conj_should_add_to_end_of_vector()
        {
            var expected = new Vector().Invoke(1, 2);
            var actual = conj(new Vector().Invoke(1), 2);

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Conj_should_add_one_item_to_a_vector()
        {
            var expected = new Vector().Invoke(1);
            var actual = conj(new Vector().Invoke(), 1);

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Conj_should_return_new_list_if_null_passed_as_the_collection()
        {
            var expected = new funclib.Components.Core.List().Invoke(1);
            var actual = conj(null, 1);

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.List>(actual);
        }

        [Test]
        public void Conj_should_return_a_empty_vector_when_no_values_are_passed()
        {
            var expected = new Vector().Invoke();
            var actual = conj();

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Conj_should_return_coll_if_not_object_are_to_be_added()
        {
            var expected = new Vector().Invoke(1);
            var actual = conj(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Conj_should_add_all_objects_passed()
        {
            var expected = new funclib.Components.Core.List().Invoke(5, 4, 3, 1, 2);
            var actual = conj(new funclib.Components.Core.List().Invoke(1, 2), 3, 4, 5);

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.List>(actual);
        }
    }
}

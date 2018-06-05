using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using vec = FunctionalLibrary.Collections.Vector;
using list = FunctionalLibrary.Collections.List;

namespace FunctionalLibrary.Tests.Collections
{
    public class VectorShould
    {
        [Test]
        public void Vector_should_create_a_new_vector_from_an_array()
        {
            var actual = vec.Create(1, 2, 3);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Vector_should_create_a_new_vector_from_a_seq_with_more_than_32_items()
        {
            var seq = list.Create(Enumerable.Range(1, 100).ToArray());
            var actual = vec.Create(seq);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Vector_should_create_a_new_vector_from_a_seq_with_less_than_32_items()
        {
            var seq = list.Create(Enumerable.Range(1, 31).ToArray());
            var actual = vec.Create(seq);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Vector_should_create_a_new_vector_from_a_seq_with_32_items()
        {
            var seq = list.Create(Enumerable.Range(1, 32).ToArray());
            var actual = vec.Create(seq);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void Vector_should_return_item_at_its_index()
        {
            var expected = 2;
            var actual = vec.Create(1, 2, 3)[1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_new_vector_with_new_value_replacing_exisiting_value_if_exists()
        {
            var expected = vec.Create(4, 2, 3);
            var actual = vec.Create(1, 2, 3).Assoc(0, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_new_vector_with_new_value_appended()
        {
            var expected = vec.Create(1, 2, 3, 4);
            var actual = vec.Create(1, 2, 3).Assoc(3, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_new_vector_with_new_value_appened_to_empty_vector()
        {
            var expected = vec.Create(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            var actual = vec.Create(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1).Assoc(19, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_all_but_last_when_pop_is_called()
        {
            var expected = vec.Create(1, 2, 3, 4);
            var actual = vec.Create(1, 2, 3, 4, 5).Pop();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_throw_error_when_i_passed_is_outside_of_bounds()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => vec.Create(1, 2, 3).Assoc(-1, 4));
            Assert.Throws<ArgumentOutOfRangeException>(() => vec.Create(1, 2, 3).Assoc(10, 4));
        }

        [Test]
        public void Vector_should_throw_index_out_of_range_when_indexer_is_passed_a_value_out_of_range()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = vec.Create(1, 2, 3)[10]; });
        }

        [Test]
        public void Invalid_operations_on_vector()
        {
            Assert.Throws<InvalidOperationException>(() => vec.Create(1, 2, 3).Add(4));
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.Generic.ICollection<object>).Add(4));
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.IList).Clear());
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.Generic.ICollection<object>).Clear());
            Assert.Throws<InvalidOperationException>(() => vec.Create(1, 2, 3).Insert(1, 4));
            Assert.Throws<InvalidOperationException>(() => vec.Create(1, 2, 3).Remove(1));
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.Generic.ICollection<object>).Remove(1));
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.IList).RemoveAt(1));
            Assert.Throws<InvalidOperationException>(() => (vec.Create(1, 2, 3) as System.Collections.Generic.IList<object>).RemoveAt(1));
            Assert.Throws<InvalidOperationException>(() => vec.Create(1, 2, 3)[1] = 5);
            Assert.Throws<InvalidOperationException>(() => vec.Create(1, 2, 3)[1, 4] = 5);
        }


        [Test]
        public void Vector_should_be_fixed_size()
        {
            var actual = vec.Create(1, 2, 3).IsFixedSize;

            Assert.IsTrue(actual);
        }

        [Test]
        public void Vector_should_be_read_only()
        {
            var actual = (vec.Create(1, 2, 3) as System.Collections.IList).IsReadOnly;

            Assert.IsTrue(actual);
        }

        [Test]
        public void Vector_should_be_synchronized()
        {
            var actual = vec.Create(1, 2, 3).IsSynchronized;

            Assert.IsTrue(actual);
        }

        [Test]
        public void Vector_should_return_itself_for_sync_root()
        {
            var expected = vec.Create(1, 2, 3);
            var actual = expected.SyncRoot;

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Vector_should_equal_another_vector_with_same_values()
        {
            var expected = vec.Create(1, 2, 3);
            var actual = vec.Create(1, 2, 3);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void Vector_should_not_equal_another_vector_with_different_values()
        {
            var expected = vec.Create(1, 2, 4);
            var actual = vec.Create(1, 2, 3);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void Vector_should_equal_an_IList_with_same_values()
        {
            var expected = vec.Create(1, 2, 3);
            var actual = list.Create(1, 2, 3);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void Vector_should_not_equal_an_IList_with_different_values()
        {
            var expected = vec.Create(1, 2, 4);
            var actual = list.Create(1, 2, 3);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void Vector_should_not_equal_any_other_object()
        {
            var expected = vec.Create(1, 2, 4);
            var actual = 1;

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void Vector_should_return_the_same_hash_code_between_two_vectors_with_same_value()
        {
            var expected = vec.Create(1, 2, 3).GetHashCode();
            var actual = vec.Create(1, 2, 3).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_the_item_at_the_given_index()
        {
            var expected = "two";
            var actual = vec.Create("one", "two", "three")[1, "zero"];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_not_found_if_index_is_not_found()
        {
            var expected = "zero";
            var actual = vec.Create("one", "two", "three")[-1, "zero"];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_true_if_index_exists()
        {
            var actual = vec.Create(1, 2, 3).ContainsKey(1);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Vector_should_return_false_if_index_does_not_exists()
        {
            var actual = vec.Create(1, 2, 3).ContainsKey(10);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Vector_should_return_KeyValuePair_when_get_called_and_exists()
        {
            var expected = new System.Collections.Generic.KeyValuePair<int, object>(1, 2);
            var actual = vec.Create(1, 2, 3).Get(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_null_when_get_called_and_does_not_exist()
        {
            var actual = vec.Create(1, 2, 3).Get(4);

            Assert.IsNull(actual);
        }

        [Test]
        public void Vector_should_return_value_when_GetValue_called_and_exist()
        {
            var expected = "one";
            var actual = vec.Create("one", "two", "three").GetValue(0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_null_when_GetValue_called_and_does_not_exist()
        {
            var actual = vec.Create("one", "two", "three").GetValue(4);

            Assert.IsNull(actual);
        }

        [Test]
        public void Vector_should_return_not_found_value_when_GetValue_called_and_does_not_exist()
        {
            var expected = "four";
            var actual = vec.Create("one", "two", "three").GetValue(4, "four");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_last_item_when_peek_is_called()
        {
            var expected = 3;
            var actual = vec.Create(1, 2, 3).Peek();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vector_should_return_null_when_peek_is_called_when_empty()
        {
            var actual = vec.EMPTY.Peek();

            Assert.IsNull(actual);
        }
    }
}

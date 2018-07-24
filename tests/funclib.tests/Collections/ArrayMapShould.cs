using funclib.Collections;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Collections
{
    public class ArrayMapShould
    {
        [Test]
        public void ArrayMap_should_create_a_new_object_when_passing_array_object()
        {
            var actual = arrayMap("a", 1, "b", 2, "c", 3);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void ArrayMap_should_return_count_of_items()
        {
            var expected = 3;
            var actual = count(arrayMap("a", 1, "b", 2, "c", 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_to_map_when_called_assoc()
        {
            var expected = arrayMap("a", 1, "b", 2, "c", 3);
            var actual = assoc(arrayMap("a", 1, "b", 2), "c", 3);
            expected.Equals(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_replace_value_if_key_exists_calling_assoc()
        {
            var expected = arrayMap("a", 1, "b", 3);
            var actual = assoc(arrayMap("a", 1, "b", 2), "b", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_replace_value_if_key_exists_when_creating_items()
        {
            var expected = arrayMap("a", 1, "b", 3);
            var actual = arrayMap("a", 1, "b", 2, "b", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_convert_to_HashMap_when_the_array_gets_larger_than_16()
        {
            var actual = assoc(arrayMap(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18), 19, 20);

            Assert.IsInstanceOf<HashMap>(actual);
        }

        [Test]
        public void ArrayMap_should_throw_exception_if_create_passed_odd_number_of_items()
        {
            Assert.Throws<ArgumentException>(() =>
                arrayMap(1, 2, 3)
            );
        }

        [Test]
        public void ArrayMap_should_return_true_if_key_exists()
        {
            var actual = contains(arrayMap(1, 2, 3, 4), 1);

            Assert.IsTrue((bool)actual);
        }

        [Test]
        public void ArrayMap_should_return_KeyValuePair_when_get_called_and_exists()
        {
            var expected = 2;
            var actual = get(arrayMap(1, 2, 3, 4), 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_return_null_when_get_called_and_does_not_exist()
        {
            var actual = get(arrayMap(1, 2, 3, 4), 4);

            Assert.IsNull(actual);
        }

        [Test]
        public void ArrayMap_should_return_new_list_without_key_and_value_when_without_is_called_and_key_exists()
        {
            var expected = arrayMap(3, 4);
            var actual = dissoc(arrayMap(1, 2, 3, 4), 1);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }

        [Test]
        public void ArrayMap_shoud_return_itself_when_without_is_called_and_key_does_not_exist()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = dissoc(expected, -1);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void ArrayMap_should_be_fixed_size()
        {
            var actual = ((ArrayMap)arrayMap(1, 2, 3, 4)).IsFixedSize;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_be_read_only()
        {
            var actual = ((ArrayMap)arrayMap(1, 2, 3, 4)).IsReadOnly;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_be_synchronized()
        {
            var actual = ((ArrayMap)arrayMap(1, 2, 3, 4)).IsSynchronized;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_return_itself_for_sync_root()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = ((ArrayMap)expected).SyncRoot;

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void ArrayMap_should_return_true_when_two_maps_with_same_key_values_are_equal()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = arrayMap(1, 2, 3, 4);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_false_when_two_maps_with_same_key_values_are_not_equal()
        {
            var expected = arrayMap(1, 2, 5, 4);
            var actual = arrayMap(1, 2, 3, 4);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_false_when_equals_is_called_with_not_a_dictionay_object()
        {
            var expected = arrayMap(1, 2, 5, 4);
            var actual = 1;

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_same_hash_code_for_two_list_with_same_values()
        {
            var expected = ((ArrayMap)arrayMap(1, 2, 5, 4)).GetHashCode();
            var actual = ((ArrayMap)arrayMap(1, 2, 5, 4)).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Invalid_operations_on_arraymap()
        {
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Add(4));
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Add(4, 5));
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Add(new System.Collections.Generic.KeyValuePair<object, object>(1, 2)));
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Clear());
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Clear());
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Remove(1));
            Assert.Throws<InvalidOperationException>(() => (arrayMap(1, 2, 5, 4) as System.Collections.IDictionary).Remove(1));
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4)).Remove(new System.Collections.Generic.KeyValuePair<object, object>(1, 2)));
            Assert.Throws<InvalidOperationException>(() => ((ArrayMap)arrayMap(1, 2, 5, 4))[1] = 4);
        }

        [Test]
        public void ArrayMap_should_return_all_keys_when_Keys_property_is_requested()
        {
            var actual = (ISeq)keys(arrayMap(1, 1, 2, 2));

            int expected = 1;
            foreach (var key in actual)
            {
                Assert.AreEqual(expected, key);
                expected++;
            }
        }

        [Test]
        public void ArrayMap_should_return_all_values_when_Values_property_is_requested()
        {
            var actual = (ISeq)values(arrayMap(1, 1, 2, 2));

            int expected = 1;
            foreach (var key in actual)
            {
                Assert.AreEqual(expected, key);
                expected++;
            }
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_KeyValuePair()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = conj(arrayMap(1, 2), new KeyValuePair(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_DictionaryEntry()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = conj(arrayMap(1, 2), new System.Collections.DictionaryEntry(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_Vector()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = conj(arrayMap(1, 2), vector(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_throw_exception_when_cons_is_called_with_a_Vector_with_a_count_not_2()
        {
            Assert.Throws<ArgumentException>(() =>
                conj(arrayMap(1, 2), vector(3, 4, 5))
            );
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_array_of_KeyValuePair()
        {
            var expected = arrayMap(1, 2, 3, 4);
            var actual = conj(arrayMap(1, 2), new KeyValuePair[] { new KeyValuePair(3, 4) });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_test_both_key_and_value_and_return_true_when_contains_is_called_with_KeyValuePair_and_both_match()
        {
            Assert.IsTrue((bool)contains(arrayMap(1, 2, 3, 4, 5, null), 3));
            Assert.IsTrue((bool)contains(arrayMap(1, 2, 3, 4, 5, null), 5));
        }

        [Test]
        public void ArrayMap_should_test_both_key_and_value_and_return_false_when_contains_is_called_with_KeyValuePair_and_one_is_wrong()
        {
            Assert.IsFalse((bool)contains(arrayMap(1, 2, 3, 4), 4));
            Assert.IsFalse((bool)contains(arrayMap(1, 2, 3, 4), null));
        }
    }
}

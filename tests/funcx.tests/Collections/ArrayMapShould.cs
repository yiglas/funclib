﻿using FunctionalLibrary.Collections;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using map = FunctionalLibrary.Collections.ArrayMap;
using vec = FunctionalLibrary.Collections.Vector;

namespace FunctionalLibrary.Tests.Collections
{
    public class ArrayMapShould
    {
        [Test]
        public void ArrayMap_should_create_a_new_object_when_passing_array_object()
        {
            var actual = map.Create("a", 1, "b", 2, "c", 3);

            Assert.IsNotNull(actual);
        }

        [Test]
        public void ArrayMap_should_return_count_of_items()
        {
            var expected = 3;
            var actual = map.Create("a", 1, "b", 2, "c", 3).Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_to_map_when_called_assoc()
        {
            var expected = map.Create("a", 1, "b", 2, "c", 3);
            var actual = map.Create("a", 1, "b", 2).Assoc("c", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_replace_value_if_key_exists_calling_assoc()
        {
            var expected = map.Create("a", 1, "b", 3);
            var actual = map.Create("a", 1, "b", 2).Assoc("b", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_replace_value_if_key_exists_when_creating_items()
        {
            var expected = map.Create("a", 1, "b", 3);
            var actual = map.Create("a", 1, "b", 2, "b", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_convert_to_HashMap_when_the_array_gets_larger_than_16()
        {
            var actual = map.Create(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18).Assoc(19, 20);

            Assert.IsInstanceOf<HashMap>(actual);
        }

        [Test]
        public void ArrayMap_should_throw_exception_if_create_passed_odd_number_of_items()
        {
            Assert.Throws<ArgumentException>(() =>
                map.Create(1, 2, 3)
            );
        }

        [Test]
        public void ArrayMap_should_return_true_if_key_exists()
        {
            var actual = map.Create(1, 2, 3, 4).ContainsKey(1);

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_return_KeyValuePair_when_get_called_and_exists()
        {
            var expected = new System.Collections.Generic.KeyValuePair<int, object>(1, 2);
            var actual = map.Create(1, 2, 3, 4).Get(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_return_null_when_get_called_and_does_not_exist()
        {
            var actual = map.Create(1, 2, 3, 4).Get(4);

            Assert.IsNull(actual);
        }

        [Test]
        public void ArrayMap_should_return_new_list_without_key_and_value_when_without_is_called_and_key_exists()
        {
            var expected = map.Create(3, 4);
            var actual = map.Create(1, 2, 3, 4).Without(1);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }

        [Test]
        public void ArrayMap_shoud_return_itself_when_without_is_called_and_key_does_not_exist()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = expected.Without(-1);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void ArrayMap_should_be_fixed_size()
        {
            var actual = map.Create(1, 2, 3, 4).IsFixedSize;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_be_read_only()
        {
            var actual = map.Create(1, 2, 3, 4).IsReadOnly;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_be_synchronized()
        {
            var actual = map.Create(1, 2, 3, 4).IsSynchronized;

            Assert.IsTrue(actual);
        }

        [Test]
        public void ArrayMap_should_return_itself_for_sync_root()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = expected.SyncRoot;

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void ArrayMap_should_return_true_when_two_maps_with_same_key_values_are_equal()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = map.Create(1, 2, 3, 4);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_false_when_two_maps_with_same_key_values_are_not_equal()
        {
            var expected = map.Create(1, 2, 5, 4);
            var actual = map.Create(1, 2, 3, 4);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_false_when_equals_is_called_with_not_a_dictionay_object()
        {
            var expected = map.Create(1, 2, 5, 4);
            var actual = 1;

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void ArrayMap_should_return_same_hash_code_for_two_list_with_same_values()
        {
            var expected = map.Create(1, 2, 5, 4).GetHashCode();
            var actual = map.Create(1, 2, 5, 4).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Invalid_operations_on_arraymap()
        {
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Add(4));
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Add(4, 5));
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Add(new System.Collections.Generic.KeyValuePair<object, object>(1, 2)));
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Clear());
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Clear());
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Remove(1));
            Assert.Throws<InvalidOperationException>(() => (map.Create(1, 2, 5, 4) as System.Collections.IDictionary).Remove(1));
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4).Remove(new System.Collections.Generic.KeyValuePair<object, object>(1, 2)));
            Assert.Throws<InvalidOperationException>(() => map.Create(1, 2, 5, 4)[1] = 4);
        }

        [Test]
        public void ArrayMap_should_return_all_keys_when_Keys_property_is_requested()
        {
            var actual = map.Create(1, 1, 2, 2).Keys;

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
            var actual = map.Create(1, 1, 2, 2).Values;

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
            var expected = map.Create(1, 2, 3, 4);
            var actual = map.Create(1, 2).Cons(new System.Collections.Generic.KeyValuePair<object, object>(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_DictionaryEntry()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = map.Create(1, 2).Cons(new System.Collections.DictionaryEntry(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_Vector()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = map.Create(1, 2).Cons(vec.Create(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_throw_exception_when_cons_is_called_with_a_Vector_with_a_count_not_2()
        {
            Assert.Throws<ArgumentException>(() =>
                map.Create(1, 2).Cons(vec.Create(3, 4, 5))
            );
        }

        [Test]
        public void ArrayMap_should_add_item_and_return_new_map_when_cons_is_called_with_a_array_of_KeyValuePair()
        {
            var expected = map.Create(1, 2, 3, 4);
            var actual = map.Create(1, 2).Cons(new System.Collections.Generic.KeyValuePair<object, object>[] { new System.Collections.Generic.KeyValuePair<object, object>(3, 4) });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayMap_should_test_both_key_and_value_and_return_true_when_contains_is_called_with_KeyValuePair_and_both_match()
        {
            Assert.IsTrue(map.Create(1, 2, 3, 4, 5, null).Contains(new System.Collections.Generic.KeyValuePair<object, object>(3, 4)));
            Assert.IsTrue(map.Create(1, 2, 3, 4, 5, null).Contains(new System.Collections.Generic.KeyValuePair<object, object>(5, null)));
        }

        [Test]
        public void ArrayMap_should_test_both_key_and_value_and_return_false_when_contains_is_called_with_KeyValuePair_and_one_is_wrong(object key, object value)
        {
            Assert.IsFalse(map.Create(1, 2, 3, 4).Contains(new System.Collections.Generic.KeyValuePair<object, object>(3, 5)));
            Assert.IsFalse(map.Create(1, 2, 3, 4).Contains(new System.Collections.Generic.KeyValuePair<object, object>(4, null)));
            Assert.IsFalse(map.Create(1, 2, 3, 4).Contains(new System.Collections.Generic.KeyValuePair<object, object>(5, 1)));
        }
    }
}

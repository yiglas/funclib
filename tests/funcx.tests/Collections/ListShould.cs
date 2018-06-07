using NUnit.Framework;
using System;
using FunctionalLibrary.Collections;
using System.Text;
using list = FunctionalLibrary.Collections.List;

namespace FunctionalLibrary.Tests.Collections
{
    public class ListShould
    {
        [Test]
        public void List_should_create_new_list_by_passing_param()
        {
            var actual = list.Create(1, 2, 3);

            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void List_should_create_new_list_by_pass_an_IList()
        {
            var actual = list.Create(new System.Collections.ArrayList() { 1, 2, 3 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void List_should_return_a_new_list_with_item_cons_to_beginning()
        {
            var expected = list.Create(4, 1, 2, 3);
            var actual = list.Create(1, 2, 3).Cons(4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_the_first_item_when_first_is_called()
        {
            var expected = 1;
            var actual = list.Create(1, 2, 3).First();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_the_first_item_when_peek_is_called()
        {
            var expected = 1;
            var actual = list.Create(1, 2, 3).Peek();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_the_next_list_when_next_is_called()
        {
            var expected = list.Create(2, 3, 4);
            var actual = list.Create(1, 2, 3, 4).Next();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_null_if_theres_nothing_in_next()
        {
            var actual = list.Create(1).Next();

            Assert.IsNull(actual);
        }

        [Test]
        public void List_should_pop_off_beginning_of_list_when_pop_is_called()
        {
            var expected = list.Create(2, 3, 4);
            var actual = list.Create(1, 2, 3, 4).Pop();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_empty_list_if_theres_nothing_to_pop()
        {
            var expected = list.Create();
            var actual = list.Create(1).Pop();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_the_next_list_when_more_is_called()
        {
            var expected = list.Create(2, 3, 4);
            var actual = list.Create(1, 2, 3, 4).More();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_empty_list_if_theres_nothing_in_next_when_more_is_called()
        {
            var expected = list.Create();
            var actual = list.Create(1).More();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_the_index_of_item_when_index_of_is_called()
        {
            var expected = 1;
            var actual = list.Create("one", "two", "three").IndexOf("two");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_negative_one_when_index_of_is_called()
        {
            var expected = -1;
            var actual = list.Create("1", "2", "3").IndexOf("4");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_true_if_item_exists_in_list()
        {
            var actual = list.Create(1, 2, 3).Contains(1);

            Assert.IsTrue(actual);
        }

        [Test]
        public void List_should_return_false_if_item_does_not_exists_in_list()
        {
            var actual = list.Create(1, 2, 3).Contains(4);

            Assert.IsFalse(actual);
        }

        [Test]
        public void List_should_return_the_value_at_index_when_indexer_is_called()
        {
            var expected = "two";
            var actual = list.Create("one", "two", "three")[1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_throw_index_out_of_range_when_indexer_is_passed_a_value_out_of_range()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { var x = list.Create(1, 2, 3)[10]; });
        }

        [Test]
        public void List_should_return_same_hash_code_for_two_list_with_same_values()
        {
            var expected = list.Create(1, 2, 3).GetHashCode();
            var actual = list.Create(1, 2, 3).GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void List_should_return_true_when_two_list_with_same_values_are_equal()
        {
            var expected = list.Create(1, 2, 3);
            var actual = list.Create(1, 2, 3);

            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void List_should_return_false_when_two_list_that_are_not_the_same()
        {
            var expected = list.Create(1, 2, 4);
            var actual = list.Create(1, 2, 3);

            Assert.IsFalse(expected.Equals(actual));
        }

        [Test]
        public void Invalid_operations_on_list()
        {
            Assert.Throws<InvalidOperationException>(() => list.Create(1, 2, 3).Add(4));
            Assert.Throws<InvalidOperationException>(() => (list.Create(1, 2, 3) as System.Collections.IList).Clear());
            Assert.Throws<InvalidOperationException>(() => list.Create(1, 2, 3).Insert(1, 4));
            Assert.Throws<InvalidOperationException>(() => list.Create(1, 2, 3).Remove(1));
            Assert.Throws<InvalidOperationException>(() => (list.Create(1, 2, 3) as System.Collections.IList).RemoveAt(1));
            Assert.Throws<InvalidOperationException>(() => list.Create(1, 2, 3)[1] = 4);
        }

        [Test]
        public void List_should_be_fixed_size()
        {
            var actual = list.Create(1, 2, 3).IsFixedSize;

            Assert.IsTrue(actual);
        }

        [Test]
        public void List_should_be_read_only()
        {
            var actual = (list.Create(1, 2, 3) as System.Collections.IList).IsReadOnly;

            Assert.IsTrue(actual);
        }

        [Test]
        public void List_should_be_synchronized()
        {
            var actual = list.Create(1, 2, 3).IsSynchronized;

            Assert.IsTrue(actual);
        }

        [Test]
        public void List_should_return_itself_for_sync_root()
        {
            var expected = list.Create(1, 2, 3);
            var actual = expected.SyncRoot;

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void List_should_return_itself_when_seq_is_called()
        {
            var expected = list.Create(1, 2, 3);
            var actual = expected.Seq();

            Assert.IsTrue(expected == actual);
        }
    }
}

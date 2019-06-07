using NUnit.Framework;
using System;
using funclib.Collections.Generic;
using System.Text;
using System.Linq;

namespace funclib.Tests.Collections.Generic
{
    public class VectorShould
    {
        [Test]
        public void Vector_should_create_new_vector_by_passing_iseq()
        {
            var expected = Vector<int>.Create(1, 2, 3);
            var actual = Vector<int>.Create(expected);

            Assert.AreEqual(expected, actual);
            Assert.AreNotSame(expected, actual);
        }

        [Test]
        public void Vector_should_create_new_vector_by_passing_param()
        {
            var actual = Vector<int>.Create(1, 2, 3);

            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void Vector_should_create_new_vector_by_passing_param_of_more_than_32_items()
        {
            // var actual = Vector<int>.Create(Enumerable.Range(0, 40).ToArray());

            // Assert.IsNotNull(actual);
            // Assert.AreEqual(3, actual.Count);
        }

        [TestCase(3, 4, 1, 2, 3, 4)]
        [TestCase(0, 2, 2, 2, 3)]
        public void Vector_Assoc_should_item_in_correct_place(int i, int value, params int[] expected)
        {
            var actual = Vector<int>.Create(1, 2, 3).Assoc(i, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(10)]
        public void Vector_Assoc_should_throw_exception_if_index_out_of_range(int i)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Vector<int>.Create(1, 2, 3).Assoc(i, 5));
        }

        [Test]
        public void Vector_Empty_should_return_empty_vector()
        {
            var actual = Vector<int>.Create(1, 2, 3).Empty();

            Assert.IsEmpty(actual);
            Assert.IsInstanceOf<Vector<int>>(actual);
        }

        [Test]
        public void Vector_Pop_throws_exception_trying_to_pop_empty_vector()
        {
            Assert.Throws<InvalidOperationException>(() => Vector<int>.EMPTY.Pop());
        }

        [Test]
        public void Vector_Pop_returns_empty_vector_if_vector_contains_only_one_item()
        {
            var actual = Vector<int>.Create(1).Empty();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void Vector_Pop_returns_vector_without_last_item()
        {
            var expected = new [] { 1, 2, 3 };
            var actual = Vector<int>.Create(1, 2, 3, 4).Pop();

            Assert.AreEqual(expected, actual);
        }
    }
}
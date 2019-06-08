using System;
using funclib.Collections.Generic;
using NUnit.Framework;

namespace funclib.Tests.Collections.Generic
{
    public class KeyValuePairShould
    {
        [Test]
        public void KeyValuePair_Index_passing_1_should_return_the_value()
        {
            var expected = "one";
            var kvp = KeyValuePair<int, string>.Create(1, "one");
            string actual = kvp[1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KeyValuePair_Index_passing_o_should_return_the_key()
        {
            var expected = 1;
            var kvp = KeyValuePair<int, string>.Create(1, "one");
            int actual = kvp[0];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KeyValuePair_Index_should_throw_exception_when_passing_other_than_0_or_1()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");
            UnionType<int, string> actual;

            Assert.Throws<ArgumentOutOfRangeException>(() =>  actual = kvp[-1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual = kvp[2]);
        }

        [Test]
        public void KeyValuePair_ToTransient_should_throw_exception()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");

            Assert.Throws<NotImplementedException>(() => kvp.ToTransient());
        }

        [Test]
        public void KeyValuePair_Assoc_should_return_vector_with_new_value_added()
        {
            var expected = new UnionType<int, string>[] { 1, "one", "two" };

            var kvp = KeyValuePair<int, string>.Create(1, "one");
            var actual = kvp.Assoc(2, "two");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
        }

        [Test]
        public void KeyValuePair_Cons_should_return_vector_with_new_value_added()
        {
            var expected = new UnionType<int, string>[] { 1, "one", "two" };

            var kvp = KeyValuePair<int, string>.Create(1, "one");
            var actual = kvp.Cons("two");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
        }

        [Test]
        public void KeyValuePair_ContainsKey_should_return_true_if_passed_0_or_1_otherwise_false()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");

            Assert.True(kvp.ContainsKey(0));
            Assert.True(kvp.ContainsKey(1));
            Assert.False(kvp.ContainsKey(2));
        }

        [Test]
        public void KeyValuePair_Get_returns_item_at_index()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");

            Assert.AreEqual(0, kvp.Get(0).Key);
            Assert.AreEqual(1, (int)kvp.Get(0).Value);

            Assert.AreEqual(1, kvp.Get(1).Key);
            Assert.AreEqual("one", (string)kvp.Get(1).Value);
        }

        [Test]
        public void KeyValuePair_Empty_should_return_null()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");

            Assert.IsNull(kvp.Empty());
        }

        [Test]
        public void KeyValuePair_Peek_should_return_the_value()
        {
            var kvp = KeyValuePair<int, string>.Create(1, "one");

            Assert.AreEqual("one", (string)kvp.Peek());
            Assert.True("one" == kvp.Peek());
        }
    }
}

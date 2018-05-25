using NUnit.Framework;
using System;
using funcx.Collections;
using System.Text;

namespace funcx.tests.Collections
{
    public class ListShould
    {
        [Test]
        public void List_should_return_new_list_when_cons_is_added()
        {
            var expected = new funcx.Collections.List(1);
            var actual = expected.Cons(2);

            Assert.AreNotSame(expected, actual);
        }

        [Test]
        public void List_should_return_a_list_when_created_with_and_Enumerable()
        {
            var actual = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });

            Assert.AreEqual(4, actual.Count);
        }

        [Test]
        public void List_should_be_create_with_no_items()
        {
            var actual = new funcx.Collections.List();

            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void List_should_return_empty_list_when_called_Empty()
        {
            var actual = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });
            actual = actual.Empty() as IList;

            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void List_should_pass_back_first_item_when_called_First()
        {
            var actual = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });

            Assert.AreEqual(1, actual.First());
        }

        [Test]
        public void List_should_return_first_item_after_cons()
        {
            var actual = new funcx.Collections.List().Cons(1).Cons(2);

            Assert.AreEqual(2, actual.First());
        }

        [Test]
        public void List_should_return_rest_of_the_items_when_called_next()
        {
            var actual = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });

            Assert.AreEqual(3, actual.Next().Count);
        }

        [Test]
        public void List_should_all_foreach()
        {
            var list = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });
            var actual = false;

            foreach (var item in list)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Test]
        public void List_should_allow_indexing()
        {
            var list = funcx.Collections.List.Create(new object[] { 1, 2, 3, "four" });

            var actaul = list[1];

            Assert.AreEqual(2, actaul);
        }
    }
}

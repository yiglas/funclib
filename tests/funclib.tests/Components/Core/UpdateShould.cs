using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class UpdateShould
    {
        [Test]
        public void Update_should_update_value_for_given_key_but_not_update_the_source_stucture()
        {
            var p = arrayMap(":name", "James", ":age", 26);

            var actual = update(p, ":age", new Inc());

            Assert.AreNotEqual(p, actual);
        }

        [Test]
        public void Update_should_update_value_for_given_key()
        {
            var p = arrayMap(":name", "James", ":age", 26);

            var expected = arrayMap(":name", "James", ":age", 27);
            var actual = update(p, ":age", new Inc());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_update_value_for_give_key_with_paramerters()
        {
            var p = arrayMap(":name", "James", ":age", 26);

            var expected = arrayMap(":name", "James", ":age", 36);
            var actual = update(p, ":age", new Plus(), 10);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_add_key_value_if_key_doesnot_exist()
        {
            var p = arrayMap();

            var expected = arrayMap(":some-key", "foo");
            var actual = update(p, ":some-key", new Function<object, object>(x => str("foo", x)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_also_work_with_vectors()
        {
            var expected = new Vector().Invoke(2, 2, 3);
            var actual = update(new Vector().Invoke(1, 2, 3), 0, new Inc());

            Assert.AreEqual(expected, actual);
        }
    }
}

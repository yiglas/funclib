using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class UpdateShould
    {
        [Test]
        public void Update_should_update_value_for_given_key_but_not_update_the_source_stucture()
        {
            var p = funclib.Core.ArrayMap(":name", "James", ":age", 26);

            var actual = funclib.Core.Update(p, ":age", new Inc());

            Assert.AreNotEqual(p, actual);
        }

        [Test]
        public void Update_should_update_value_for_given_key()
        {
            var p = funclib.Core.ArrayMap(":name", "James", ":age", 26);

            var expected = funclib.Core.ArrayMap(":name", "James", ":age", 27);
            var actual = funclib.Core.Update(p, ":age", new Inc());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_update_value_for_give_key_with_paramerters()
        {
            var p = funclib.Core.ArrayMap(":name", "James", ":age", 26);

            var expected = funclib.Core.ArrayMap(":name", "James", ":age", 36);
            var actual = funclib.Core.Update(p, ":age", new Plus(), 10);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_add_key_value_if_key_doesnot_exist()
        {
            var p = funclib.Core.ArrayMap();

            var expected = funclib.Core.ArrayMap(":some-key", "foo");
            var actual = funclib.Core.Update(p, ":some-key", new Function<object, object>(x => funclib.Core.Str("foo", x)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_should_also_work_with_vectors()
        {
            var expected = funclib.Core.Vector(2, 2, 3);
            var actual = funclib.Core.Update(funclib.Core.Vector(1, 2, 3), 0, new Inc());

            Assert.AreEqual(expected, actual);
        }
    }
}

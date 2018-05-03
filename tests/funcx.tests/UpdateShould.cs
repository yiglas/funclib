using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class UpdateShould
    {
        [Test]
        public void Update_should_update_the_value_without_updating_the_original_dictionary()
        {
            var p = new Dictionary<string, object>() { ["name"] = "James", ["age"] = 26 };

            var actual = update(p, "age", (x) => inc((int)x));

            Assert.AreNotSame(p, actual);
        }

        [Test]
        public void Update_should_return_even_if_passed_an_empty_dictionary()
        {
            var actual = update<string, object>(null, "name", (x) => "foo");

            Assert.AreEqual("foo", actual["name"]);
        }
    }
}

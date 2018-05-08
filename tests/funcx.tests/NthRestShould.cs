using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class NthRestShould
    {
        [Test]
        public void Nthrest_should_return_null_if_coll_is_null()
        {
            var actual = nthrest<int>(null, 5);

            Assert.IsNull(actual);
        }

        [Test]
        public void Nthrest_should_return_empyt_list_type_if_n_is_greater_than_items_in_list()
        {
            var actual = nthrest(new int[] { 1, 2, 3 }, 5);

            Assert.AreEqual(0, actual.Count());
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class ReduceShould
    {
        [Test]
        public void Reduce_should_apply_the_following()
        {
            Assert.AreEqual(15, reduce((x, y) => x + y, new int[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(0, reduce((x, y) => x + y, new int[0]));
            Assert.AreEqual(1, reduce((x, y) => x + y, new int[] { 1 }));
            Assert.AreEqual(3, reduce((x, y) => x + y, new int[] { 1, 2 }));
            Assert.AreEqual(1, reduce((x, y) => x + y, 1, new int[0]));
            Assert.AreEqual(6, reduce((x, y) => x + y, 1, new int[] { 2, 3 }));
        }

        [Test]
        public void Reduce_should_work_by_passing_a_existing_func()
        {
            var actual = reduce(conj, new List<string>() as IList<string>, new List<string>() { "a", "b", "c" });

            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void Reduce_should_return_new_list_with_both_start_value_and_conjoined_values()
        {
            IList<int> val = new List<int>() { 1, 2, 3 };
            
            var actual = reduce(conj, val, new List<int>() { 4, 5, 6 });

            Assert.AreEqual(6, actual.Count);
        }
    }
}

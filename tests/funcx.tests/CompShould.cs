using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests
{
    public class CompShould
    {
        [Test]
        public void Comp_should_return_function_when_passed_two_functions()
        {
            var f = comp(x => x + 1, () => 1);
            var actual = f();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Comp_should_return_function_when_passed_two_functions_that_takes_one_param()
        {
            var f = comp(inc, (int x) => x);
            var actual = f(1);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Comp_should_return_function_when_passed_a_func_with_params()
        {
            var f = comp<int, int, int, int, int, int>(inc, TestCompWithParms);
            var actual = f(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(37, actual);
        }

        [Test]
        public void Comp_should_return_function_when_passed_more_than_two_functions()
        {
            var f = comp((x) => x * -1, partial<int, int, int>((x, y) => x + y, 3), partial<int, int, int>((x, y) => x * y, 2));
            var actual = map(f, new int[] { 1, 2, 3, 4 }).ToList();

            Assert.AreEqual(-5, actual[0]);
            Assert.AreEqual(-11, actual[3]);
        }

        public int TestCompWithParms(int x, int y, int z, params int[] args)
        {
            return x + y + z + reduce((a, c) => a + c, 0, args);
        }
        
    }
}

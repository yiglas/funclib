namespace funcx.tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static funcx.core;

    public class core_inc_should
    {
        [Test]
        public void Inc_should_increase_the_number_by_one()
        {
            var expected = 1;
            var actual = inc(0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Inc_should_return_same_type_as_passed_in()
        {
            Assert.IsInstanceOf(typeof(int), inc(1));
            Assert.IsInstanceOf(typeof(double), inc((double)1));
            Assert.IsInstanceOf(typeof(float), inc((float)1));
            Assert.IsInstanceOf(typeof(double), inc((double)1));
        }
    }
}

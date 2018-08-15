using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DropShould
    {
        [Test]
        public void Drop_should_work_with_arrays()
        {
            var expected = funclib.Core.List(2, 3);
            var actual = funclib.Core.Drop(1, new object[] { 1, 2, 3 });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Drop_should_return_a_lazy_seq()
        {
            var actual = funclib.Core.Drop(1, funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Drop_should_return_all_times_execute_first_n_items()
        {
            var expected = funclib.Core.List(3, 4, 5);
            var actual = funclib.Core.ToArray(funclib.Core.Drop(2, funclib.Core.List(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}

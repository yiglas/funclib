using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PartitionShould
    {
        [Test]
        public void Partition_should_drop_items_if_they_do_not_make_the_cut_off()
        {
            var actual = new Partition().Invoke(4, new Range().Invoke(6));

            Assert.AreEqual(1, count(actual));
        }

        [Test]
        public void Partition_should_start_each_loop_at_its_start_param()
        {
            var actual = new Partition().Invoke(4, 6, new Range().Invoke(20));

            Assert.AreEqual(6, first(new Second().Invoke(actual)));
        }

        [Test]
        public void Partition_should_reuse_item_if_step_is_smaller_than_size()
        {
            var actual = new Partition().Invoke(4, 3, new Range().Invoke(20));

            Assert.AreEqual(3, first(new Second().Invoke(actual)));
        }

        [Test]
        public void Partition_should_fill_the_last_parition_if_not_enough_items()
        {
            var actual = new Partition().Invoke(3, 6, new Vector().Invoke("a"), new Range().Invoke(20));

            Assert.AreEqual("a", last(last(actual)));
        }
    }
}

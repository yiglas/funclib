using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReduceShould
    {
        [Test]
        public void Reduce_should_sum_values_passed()
        {
            Assert.AreEqual(15, funclib.Core.Reduce(new Plus(), funclib.Core.Vector(1, 2, 3, 4, 5)));
            Assert.AreEqual(0, funclib.Core.Reduce(new Plus(), funclib.Core.Vector()));
            Assert.AreEqual(1, funclib.Core.Reduce(new Plus(), funclib.Core.Vector(1)));
            Assert.AreEqual(3, funclib.Core.Reduce(new Plus(), funclib.Core.Vector(1, 2)));
            Assert.AreEqual(1, funclib.Core.Reduce(new Plus(), 1, funclib.Core.Vector()));
            Assert.AreEqual(6, funclib.Core.Reduce(new Plus(), 1, funclib.Core.Vector(2, 3)));
        }

        [Test]
        public void Reduce_should_conj_vector_to_hash_set()
        {
            var expected = funclib.Core.HashSet(":a", ":b", ":c");
            var actual = funclib.Core.Reduce(new Conj(), funclib.Core.HashSet(), funclib.Core.Vector(":a", ":b", ":c"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_conj_two_vectors()
        {
            var expected = funclib.Core.Vector(1, 2, 3, 4, 5, 6);
            var actual = funclib.Core.Reduce(new Conj(), funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_cons_two_vectors_into_a_list()
        {
            var expected = funclib.Core.List(6, 5, 4, 1, 2, 3);
            var actual = funclib.Core.Reduce(new Function<object, object, object>((a, b) => funclib.Core.Cons(b, a)), funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_process_an_range()
        {
            var expected = 45;
            var actual = funclib.Core.Reduce(new Plus(), 0, funclib.Core.Range(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_be_able_to_reimplement_map()
        {
            var remap = new FunctionParams<object, object, object>((f, c) =>
            {
                var inter = funclib.Core.Apply(new Interleave(), c);
                var neuesc = new Partition().Invoke(funclib.Core.Count(c), inter);
                return funclib.Core.Reduce(new Function<object, object, object>((s, k) => funclib.Core.Conj(s, funclib.Core.Apply(f, k))), funclib.Core.Vector(), neuesc);
            });

            var expected = funclib.Core.Vector(0.0, 0.2, 0.6);
            var actual = remap.Invoke(new Multiply(), funclib.Core.Vector(0.1, 0.2, 0.3), funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_loop_over_a_string()
        {
            var expected = 488;
            var actual = funclib.Core.Reduce(new Plus(), "David");

            Assert.AreEqual(expected, actual);
        }
    }
}

﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ReduceShould
    {
        [Test]
        public void Reduce_should_sum_values_passed()
        {
            Assert.AreEqual(15, new Reduce().Invoke(new Plus(), new Vector().Invoke(1, 2, 3, 4, 5)));
            Assert.AreEqual(0, new Reduce().Invoke(new Plus(), new Vector().Invoke()));
            Assert.AreEqual(1, new Reduce().Invoke(new Plus(), new Vector().Invoke(1)));
            Assert.AreEqual(3, new Reduce().Invoke(new Plus(), new Vector().Invoke(1, 2)));
            Assert.AreEqual(1, new Reduce().Invoke(new Plus(), 1, new Vector().Invoke()));
            Assert.AreEqual(6, new Reduce().Invoke(new Plus(), 1, new Vector().Invoke(2, 3)));
        }

        [Test]
        public void Reduce_should_conj_vector_to_hash_set()
        {
            var expected = new HashSet().Invoke(":a", ":b", ":c");
            var actual = new Reduce().Invoke(new Conj(), new HashSet().Invoke(), new Vector().Invoke(":a", ":b", ":c"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_conj_two_vectors()
        {
            var expected = new Vector().Invoke(1, 2, 3, 4, 5, 6);
            var actual = new Reduce().Invoke(new Conj(), new Vector().Invoke(1, 2, 3), new Vector().Invoke(4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_cons_two_vectors_into_a_list()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(6, 5, 4, 1, 2, 3);
            var actual = new Reduce().Invoke(new Function<object, object, object>((a, b) => new Cons().Invoke(b, a)), new Vector().Invoke(1, 2, 3), new Vector().Invoke(4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_process_an_range()
        {
            var expected = 45;
            var actual = new Reduce().Invoke(new Plus(), 0, new Range().Invoke(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reduce_should_be_able_to_reimplement_map()
        {
            var remap = new FunctionParams<object, object, object>((f, c) =>
            {
                var inter = new Apply().Invoke(new Interleave(), c);
                var neuesc = new Partition().Invoke(new Count().Invoke(c), inter);
                return new Reduce().Invoke(new Function<object, object, object>((s, k) => new Conj().Invoke(s, new Apply().Invoke(f, k))), new Vector().Invoke(), neuesc);
            });

            var expected = new Vector().Invoke(0.0, 0.2, 0.6);
            var actual = remap.Invoke(new Multiply(), new Vector().Invoke(0.1, 0.2, 0.3), new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }
    }
}
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SwapǃShould
    {
        [Test]
        public void Swapǃ_should_update_the_atoms_value_based_on_the_function()
        {
            var expected = 1;
            var a = atom(0);
            var actual = swapǃ(a, Inc);

            Assert.AreEqual(expected, deref(a));
        }

        [Test]
        public void Swapǃ_should_return_a_vector()
        {
            var actaul = swapǃ(atom(0), Inc);

            Assert.IsInstanceOf<funclib.Collections.Vector>(actaul);
        }

        [Test]
        public void Swapǃ_should_return_and_update_previous()
        {
            var queue = atom(list(1, 2, 3));
            var head = ffirst(swapǃ(queue, Pop));

            Assert.AreEqual(1, head);
            Assert.AreEqual(list(2, 3), deref(queue));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_one_paramter()
        {
            var players = atom(list());

            swapǃ(players, Conj, ":player1");

            Assert.AreEqual(list(":player1"), deref(players));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_two_paramter()
        {
            var m1 = atom(arrayMap(":a", "A", ":b", "B"));

            swapǃ(m1, Assoc, ":a", "Aaay");

            Assert.AreEqual("Aaay", get(deref(m1), ":a"));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_more_paramter()
        {
            var car = atom(arrayMap(":make", "Audi", ":model", "Q3"));

            swapǃ(car, Assoc, ":make", "Q5", ":engine", "V8");


            Assert.AreEqual("Q5", get(deref(car), ":make"));
            Assert.AreEqual("V8", get(deref(car), ":engine"));
        }
    }
}

using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SwapǃShould
    {
        [Test]
        public void Swapǃ_should_update_the_atoms_value_based_on_the_function()
        {
            var expected = 1;
            var a = funclib.Core.Atom(0);
            var actual = funclib.Core.Swapǃ(a, funclib.Core.inc);

            Assert.AreEqual(expected, funclib.Core.Deref(a));
        }

        [Test]
        public void Swapǃ_should_return_a_vector()
        {
            var actaul = funclib.Core.Swapǃ(funclib.Core.Atom(0), funclib.Core.inc);

            Assert.IsInstanceOf<funclib.Collections.Vector>(actaul);
        }

        [Test]
        public void Swapǃ_should_return_and_update_previous()
        {
            var queue = funclib.Core.Atom(funclib.Core.List(1, 2, 3));
            var head = funclib.Core.FFirst(funclib.Core.Swapǃ(queue, funclib.Core.pop));

            Assert.AreEqual(1, head);
            Assert.AreEqual(funclib.Core.List(2, 3), funclib.Core.Deref(queue));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_one_paramter()
        {
            var players = funclib.Core.Atom(funclib.Core.List());

            funclib.Core.Swapǃ(players, funclib.Core.conj, ":player1");

            Assert.AreEqual(funclib.Core.List(":player1"), funclib.Core.Deref(players));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_two_paramter()
        {
            var m1 = funclib.Core.Atom(funclib.Core.ArrayMap(":a", "A", ":b", "B"));

            funclib.Core.Swapǃ(m1, funclib.Core.assoc, ":a", "Aaay");

            Assert.AreEqual("Aaay", funclib.Core.Get(funclib.Core.Deref(m1), ":a"));
        }

        [Test]
        public void Swapǃ_should_update_atom_with_more_paramter()
        {
            var car = funclib.Core.Atom(funclib.Core.ArrayMap(":make", "Audi", ":model", "Q3"));

            funclib.Core.Swapǃ(car, funclib.Core.assoc, ":make", "Q5", ":engine", "V8");


            Assert.AreEqual("Q5", funclib.Core.Get(funclib.Core.Deref(car), ":make"));
            Assert.AreEqual("V8", funclib.Core.Get(funclib.Core.Deref(car), ":engine"));
        }
    }
}

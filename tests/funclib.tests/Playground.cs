using NUnit.Framework;

namespace FunctionalLibrary.Tests
{
    public class Playground
    {

        [Test]
        public void Testing()
        {
            var list = funclib.Core.Map(funclib.Core.inc, funclib.Core.Vector(1, 2, 3));
        }


        [Test]
        public void Trying_to_figure_out_where_items_are_placed_with_array()
        {
            var actual = funclib.Core.Cons(5, new object[] { 1, 2, 3, 4 });
            var actual4 = funclib.Core.Cons(5, funclib.Core.List(1, 2, 3, 4));
            var actual2 = funclib.Core.Conj(funclib.Core.ListS(new object[] { 1, 2, 3, 4 }), 5);
            var actual5 = funclib.Core.Conj(funclib.Core.List(1, 2, 3, 4), 5);
            var actual3 = funclib.Core.Concat(new object[] { 1, 2, 3, 4 }, new object[] { 5 });
        }

        [Test]
        public void Trying_invoke_function()
        {
            var notEmpty = funclib.Core.Complement(funclib.Core.isEmpty);

            //Assert.IsFalse((bool)funclib.Core.Invoke(notEmpty, funclib.Core.Vector()));
            //Assert.IsTrue((bool)funclib.Core.Invoke(notEmpty, funclib.Core.Vector(1, 2)));

            var l = new System.Collections.Generic.List<string>();
        }
    }
}

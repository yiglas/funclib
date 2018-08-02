using NUnit.Framework;
using static funclib.core;

namespace FunctionalLibrary.Tests
{
    public class Playground
    {

        [Test]
        public void Testing()
        {
            var list = map(Inc, vector(1, 2, 3));
        }


        [Test]
        public void Trying_to_figure_out_where_items_are_placed_with_array()
        {
            var actual = cons(5, new object[] { 1, 2, 3, 4 });
            var actual4 = cons(5, list(1, 2, 3, 4));
            var actual2 = conj(listS(new object[] { 1, 2, 3, 4 }), 5);
            var actual5 = conj(list(1, 2, 3, 4), 5);
            var actual3 = concat(new object[] { 1, 2, 3, 4 }, new object[] { 5 });
        }

        [Test]
        public void Trying_invoke_function()
        {
            var notEmpty = complement(IsEmpty);

            //Assert.IsFalse((bool)invoke(notEmpty, vector()));
            //Assert.IsTrue((bool)invoke(notEmpty, vector(1, 2)));
        }
    }
}

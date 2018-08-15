using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class PeekShould
    {
        //[Test]
        //public void Peek_should_be_more_efficient_than_last_for_large_vectors()
        //{
        //    var largeVec = funclib.Core.Vec(funclib.Core.Range(0, 100));

        //    var sw = Stopwatch.StartNew();
        //    var actual = peek(largeVec);
        //    sw.Stop();
        //    var peekTime = sw.ElapsedMilliseconds;

        //    sw.Restart();
        //    last(largeVec);
        //    sw.Stop();
        //    var lastTime = sw.ElapsedMilliseconds;

        //    Assert.LessOrEqual(peekTime, lastTime);
        //}

        [Test]
        public void Peek_should_return_the_last_element_of_a_vector()
        {
            var expected = 3;
            var actual = funclib.Core.Peek(funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_should_return_the_first_element_of_a_list()
        {
            var expected = 1;
            var actual = funclib.Core.Peek(funclib.Core.List(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_should_return_null_if_empty_vector()
        {
            Assert.IsNull(funclib.Core.Peek(funclib.Core.Vector()));
        }

        [Test]
        public void Peek_should_return_null_when_null_is_passed()
        {
            Assert.IsNull(funclib.Core.Peek(null));
        }

        [Test]
        public void Peek_should_return_null_if_empty_list()
        {
            Assert.IsNull(funclib.Core.Peek(funclib.Core.List()));
        }
    }
}

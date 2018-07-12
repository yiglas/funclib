using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests
{
    public class Playground
    {
        public static object map(object f, object coll) => new Map().Invoke(f, coll);
        public static object inc(object x) => new Inc().Invoke(x);
        public static object dec(object x) => new Dec().Invoke(x);
        public static object vector(object x, object y) => new Vector().Invoke(x, y);

        public static Inc Inc => new Inc();
        public static Dec Dec => new Dec();

        [Test]
        public void Testing()
        {
            var n = inc(1);
            var x = map(Inc, vector(1, 2));
            var y = map(Dec, vector(1, 2));
        }
    }
}

//namespace funclib.Tests.Components.Core
//{
//    using FunctionalLibrary;
//    using NUnit.Framework;
//    using System;
//    using System.Collections.Generic;

//    public class ActivatorShould
//    {
//        [Test]
//        public void Basline_should_be_slower_than_measure()
//        {
//            var perf = new ActivatorPerformance();
//            var results = perf.Measure();

//            Assert.Greater(results.baseline, results.b);
//        }
//    }

//    public class ActivatorPerformance: Performance
//    {
//        const int DEFAULT_ITERATIONS = 1_000_000;

//        public ActivatorPerformance() : base("Activator", "", DEFAULT_ITERATIONS) { }

//        protected override bool BaselineTest()
//        {
//            var type = typeof(List<int>);
//            for (int i = 0; i < this.Iterations; i++)
//            {
//                var obj = System.Activator.CreateInstance(type);
//                if (obj.GetType() != typeof(List<int>))
//                    throw new InvalidOperationException("Constructed object is not List<int>");
//            }
//            return true;
//        }

//        protected override bool MeasureTestB()
//        {
//            var type = typeof(List<int>);
//            for (int i = 0; i < this.Iterations; i++)
//            {
//                var obj = FunctionalLibrary.Activator.CreateInstance(type);
//                if (obj.GetType() != typeof(List<int>))
//                    throw new InvalidOperationException("Constructed object is not List<int>");
//            }
//            return true;
//        }

//        protected override bool MeasureTestC() => false;
//    }
//}

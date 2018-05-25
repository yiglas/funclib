using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace funcx.tests.Core
{
    public class PerformanceResult
    {
        public int MillisecondsA { get; }
        public int MillisecondsB { get; }
        public int CollectionsA { get; }
        public int CollectionsB { get; }

        public PerformanceResult(int msA, int msB, int collA, int collB)
        {
            this.MillisecondsA = msA;
            this.MillisecondsB = msB;
            this.CollectionsA = collA;
            this.CollectionsB = collB;
        }

    }

    public class Performance
    {
        const int DEFAULT_REPETITIONS = 10;

        public string Name { get; }
        public string Description { get; }
        public int Iterations { get; }

        protected virtual bool BaselineTest() => false;
        protected virtual bool MeasureTestB() => false;
        protected virtual bool MeasureTestC() => false;

        public Performance(string name, string description, int iterations)
        {
            this.Name = name;
            this.Description = description;
            this.Iterations = iterations;
        }

        public (int baseline, int b, int c) Measure()
        {
            long totalBaseline = 0;
            long totalB = 0;
            long totalC = 0;
            
            totalBaseline = run(BaselineTest);
            totalB = run(MeasureTestB);
            totalC = run(MeasureTestC);

            return (
                (int)(totalBaseline / DEFAULT_REPETITIONS),
                (int)(totalB / DEFAULT_REPETITIONS),
                (int)(totalC / DEFAULT_REPETITIONS)
                );

            long run(Func<bool> f)
            {
                var sw = new Stopwatch();
                long total = 0;

                for (long i = 0; i < DEFAULT_REPETITIONS; i++)
                {
                    sw.Restart();
                    var implemented = f();
                    sw.Stop();
                    if (implemented)
                        total += sw.ElapsedMilliseconds;
                }

                return total;
            }
        }
    }
}

using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Range :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke() => new Iterate().Invoke(new Inc(), 0);

        public object Invoke(object end) =>
            end is long e
                ? Collections.LongRange.Create(e)
                : Collections.Range.Create(end);

        public object Invoke(object start, object end) => 
            start is long s && end is long e
                ? Collections.LongRange.Create(s, e)
                : Collections.Range.Create(start, end);

        public object Invoke(object start, object end, object step) =>
            start is long s && end is long e && step is long p
                ? Collections.LongRange.Create(s, e, p)
                : Collections.Range.Create(start, end, step);
    }
}

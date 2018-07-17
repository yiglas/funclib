using System;
using System.Text;

namespace funclib.Components.Core
{
    public class ReSeq :
        IFunction<object, object, object>
    {
        public object Invoke(object re, object s)
        {
            var m = (FunctionalLibrary.ReMatcher)new ReMatcher().Invoke(re, s);

            return step();

            object step()
            {
                if (m.Find())
                    return new Cons().Invoke(new ReGroups().Invoke(m), new LazySeq(step));

                return null;
            }
        }
    }
}

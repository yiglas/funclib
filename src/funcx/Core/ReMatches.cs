using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ReMatches :
        IFunction<object, object, object>
    {
        public object Invoke(object re, object s)
        {
            var m = (FunctionalLibrary.ReMatcher)new ReMatcher().Invoke(re, s);
            if (m.Matches())
                return new ReGroups().Invoke(m);

            return null;
        }
    }
}

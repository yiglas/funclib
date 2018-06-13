using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Interpose :
        IFunction<object, object, object>
    {
        public object Invoke(object sep, object coll) =>
            new Drop().Invoke(1, new Interleave().Invoke(new Repeat().Invoke(sep), coll));
    }
}
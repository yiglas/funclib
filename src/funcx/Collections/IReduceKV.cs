using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IReduceKV
    {
        object Reduce(IFunction<object, object, object, object> f, object init);
    }
}

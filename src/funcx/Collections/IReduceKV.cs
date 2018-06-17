using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IReduceKV
    {
        object ReduceKV(IFunction f, object init);
    }
}

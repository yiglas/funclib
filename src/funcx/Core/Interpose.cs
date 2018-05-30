using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Interpose<TSeparator> :
        IFunction<TSeparator, IEnumerable, IEnumerable<object>>
    {
        public IEnumerable<object> Invoke(TSeparator sep, IEnumerable coll) =>
            new Drop<object>().Invoke(1, new Interleave().Invoke(new Repeat<TSeparator>().Invoke(sep), coll));
    }
}
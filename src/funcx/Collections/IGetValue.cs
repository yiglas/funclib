using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    public interface IGetValue
    {
        object GetValue(object key);
        object GetValue(object key, object notFound);
    }
}

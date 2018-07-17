using System;
using System.Text;

namespace funclib.Collections
{
    public interface IGetValue
    {
        object GetValue(object key);
        object GetValue(object key, object notFound);
    }
}

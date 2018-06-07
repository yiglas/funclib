using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IGetValue
    {
        object GetValue(object key);
        object GetValue(object key, object notFound);
    }
}

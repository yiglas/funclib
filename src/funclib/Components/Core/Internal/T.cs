using funclib.Components.Core.Generic;

namespace funclib.Components.Core.Internal
{
    class T :
        IFunction<object, bool>
    {
        public bool Invoke(object source) => true;
    }
}
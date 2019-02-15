using funclib.Components.Core.Generic;

namespace funclib.Components.Core.Internal
{
    class F :
        IFunction<object, bool>
    {
        public bool Invoke(object source)
        {
            if (source is null)
                return true;
            
            if (source is bool b)
                return !b;
            
            return false;
        }
    }
}
using funclib.Components.Core.Generic;

namespace funclib.Components.Core.Internal
{
    class T :
        IFunction<object, bool>
    {
        static F f = new F();

        public bool Invoke(object source) => !f.Invoke(source);
    }
}
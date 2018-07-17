using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Into1 :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from) =>
            to is IEditableCollection e
                ? new Persistentǃ().Invoke(new Reduce1().Invoke(new Conjǃ(), new Transient().Invoke(to), from))
                : new Reduce1().Invoke(new Conj(), to, from);
    }
}

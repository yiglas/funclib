using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Into1 :
        IFunction<object, object, object>
    {
        public object Invoke(object to, object from) =>
            to is IEditableCollection e
                ? new Persistentǃ().Invoke(new Reduce1().Invoke(new ConjT(), new Transient().Invoke(to), from))
                : new Reduce1().Invoke(new Conj(), to, from);
    }
}

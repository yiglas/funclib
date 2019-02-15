using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new collection consisting of to with all of the items of from conjoined.
    /// </summary>
    public class Into :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a new collection consisting of to with all of the items of from conjoined.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.Vector.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.Vector.EMPTY;
        /// <summary>
        /// Returns a new collection consisting of to with all of the items of from conjoined.
        /// </summary>
        /// <param name="to">Object returned.</param>
        /// <returns>
        /// Returns the to object.
        /// </returns>
        public object Invoke(object to) => to;
        /// <summary>
        /// Returns a new collection consisting of to with all of the items of from conjoined.
        /// </summary>
        /// <param name="to">Object to conjoin values to.</param>
        /// <param name="from">Object pulling values to be conjoined.</param>
        /// <returns>
        /// Returns a new collection with the same data type of to consisting of to with all of the items of from conjoined.
        /// </returns>
        public object Invoke(object to, object from)
        {
            if (to is IEditableCollection)
                return funclib.Core.Persistentǃ(
                    funclib.Core.Reduce(
                        funclib.Core.conjǃ, 
                        funclib.Core.Transient(to), 
                        from));
            
            return funclib.Core.Reduce(funclib.Core.conj, to, from);
        }
        /// <summary>
        /// Returns a new collection consisting of to with all of the items of from conjoined. 
        /// </summary>
        /// <param name="to">Object to conjoin values to.</param>
        /// <param name="xform">A transducer</param>
        /// <param name="from">Object pulling values to be conjoined.</param>
        /// <returns>
        /// Returns a new collection with the same data type of to consisting of to with all of the items of from conjoined.
        /// </returns>
        public object Invoke(object to, object xform, object from)
        {
            if (to is IEditableCollection)
                return funclib.Core.Persistentǃ(
                    funclib.Core.Transduce(
                        xform, 
                        funclib.Core.conjǃ, 
                        funclib.Core.Transient(to), 
                        from));
            
            return funclib.Core.Transduce(xform, funclib.Core.conj, to, from);
        }
    }
}

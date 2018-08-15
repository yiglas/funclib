using funclib.Components.Core.Generic;
using funclib.Collections;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new <see cref="Collections.SortedMap"/> with supplied mappings. If any keys are
    /// equal, they are handled as if by repeated uses of assoc.
    /// </summary>
    public class SortedMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a new <see cref="Collections.SortedMap"/> with supplied mappings. If any keys are
        /// equal, they are handled as if by repeated uses of assoc.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.SortedMap.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.SortedMap.EMPTY;
        /// <summary>
        /// Returns a new <see cref="Collections.SortedMap"/> with supplied mappings. If any keys are
        /// equal, they are handled as if by repeated uses of assoc.
        /// </summary>
        /// <param name="keyvals">Key/value pairs adding to the <see cref="Collections.SortedMap"/> data structure.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.SortedMap"/> with supplied mappings. If any keys are
        /// equal, they are handled as if by repeated uses of assoc.
        /// </returns>
        public object Invoke(params object[] keyvals) => Collections.SortedMap.Create((ISeq)funclib.Core.Seq(keyvals));
    }
}

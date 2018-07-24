using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes any nested combination of <see cref="funclib.Collections.ISequential"/> 
    /// things (<see cref="Collections.List"/>, <see cref="Collections.Vector"/>, etc.) and returns
    /// their contents as a single, flat sequence.  <see cref="Flatten.Invoke(null)"/> returns an
    /// empty sequence.
    /// </summary>
    public class Flatten :
        IFunction<object, object>
    {
        /// <summary>
        /// Takes any nested combination of <see cref="funclib.Collections.ISequential"/> 
        /// things (<see cref="Collections.List"/>, <see cref="Collections.Vector"/>, etc.) and returns
        /// their contents as a single, flat sequence.  <see cref="Flatten.Invoke(null)"/> returns an
        /// empty sequence.
        /// </summary>
        /// <param name="x">Object to flatten.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> that when invoked flattens the sequence.
        /// </returns>
        public object Invoke(object x) =>
            filter(complement(funclib.Core.IsSequential), rest(treeSeq(funclib.Core.IsSequential, funclib.Core.Seq, x)));
    }
}

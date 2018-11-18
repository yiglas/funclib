using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if <see cref="IFunction{T1, TResult}"/> pred is a logical 
    /// true for every item in the coll, otherwise false
    /// </summary>
    public class IsEvery :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns true if <see cref="IFunction{T1, TResult}"/> pred is a logical 
        /// true for every item in the coll, otherwise false
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">The collection to test.</param>
        /// <returns>
        /// Returns true if <see cref="IFunction{T1, TResult}"/> pred is a logical 
        /// true for every item in the coll, otherwise false
        /// </returns>
        public object Invoke(object pred, object coll)
        {
            if ((bool)funclib.Core.IsNull(funclib.Core.Seq(coll))) return true;
            if ((bool)funclib.Core.Truthy(funclib.Core.Invoke(pred, funclib.Core.First(coll))))
                return Invoke(pred, funclib.Core.Next(coll));
            return false;
        }
    }
}

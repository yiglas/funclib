﻿using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
    /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
    /// a new value, and returns a new structure. If the key does not exists, null is passed as 
    /// the old value.
    /// </summary>
    public class Update :
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunction<object, object, object, object, object, object>,
        IFunction<object, object, object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object, object, object>
    {
        /// <summary>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.        
        /// </summary>
        /// <param name="m">An object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="k">The key for the value to update.</param>
        /// <param name="f">A <see cref="IFunction"/> that takes the old value and any additional args and outputs the new value for the key.</param>
        /// <returns>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value. 
        /// </returns>
        public object Invoke(object m, object k, object f) => funclib.Core.Assoc(m, k, funclib.Core.Invoke(f, funclib.Core.Get(m, k)));
        /// <summary>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.   
        /// </summary>
        /// <param name="m">An object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="k">The key for the value to update.</param>
        /// <param name="f">A <see cref="IFunction"/> that takes the old value and any additional args and outputs the new value for the key.</param>
        /// <param name="x">Second argument to the passed in function.</param>
        /// <returns>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.  
        /// </returns>
        public object Invoke(object m, object k, object f, object x) => 
            funclib.Core.Assoc(m, k, funclib.Core.Invoke(f, funclib.Core.Get(m, k), x));
        /// <summary>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.   
        /// </summary>
        /// <param name="m">An object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="k">The key for the value to update.</param>
        /// <param name="f">A <see cref="IFunction"/> that takes the old value and any additional args and outputs the new value for the key.</param>
        /// <param name="x">Second argument to the passed in function.</param>
        /// <param name="y">Third argument to the passed in function.</param>
        /// <returns>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.   
        /// </returns>
        public object Invoke(object m, object k, object f, object x, object y) =>
            funclib.Core.Assoc(m, k, funclib.Core.Invoke(f, funclib.Core.Get(m, k), x, y));
        /// <summary>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.   
        /// </summary>
        /// <param name="m">An object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="k">The key for the value to update.</param>
        /// <param name="f">A <see cref="IFunction"/> that takes the old value and any additional args and outputs the new value for the key.</param>
        /// <param name="x">Second argument to the passed in function.</param>
        /// <param name="y">Third argument to the passed in function.</param>
        /// <param name="z">Fourth argument to the passed in function.</param>
        /// <returns>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.  
        /// </returns>
        public object Invoke(object m, object k, object f, object x, object y, object z) =>
            funclib.Core.Assoc(m, k, funclib.Core.Invoke(f, funclib.Core.Get(m, k), x, y, z));
        /// <summary>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value.   
        /// </summary>
        /// <param name="m">An object that implements the <see cref="IAssociative"/> interface.</param>
        /// <param name="k">The key for the value to update.</param>
        /// <param name="f">A <see cref="IFunction"/> that takes the old value and any additional args and outputs the new value for the key.</param>
        /// <param name="x">Second argument to the passed in function.</param>
        /// <param name="y">Third argument to the passed in function.</param>
        /// <param name="z">Fourth argument to the passed in function.</param>
        /// <param name="more">Rest of the arguments to the passed in function.</param>
        /// <returns>
        /// 'Updates' a value in an <see cref="IAssociative"/> structure. where k is a key and f is
        /// a <see cref="IFunction"/> that will take the old value and any supplied args and return 
        /// a new value, and returns a new structure. If the key does not exists, null is passed as 
        /// the old value. 
        /// </returns>
        public object Invoke(object m, object k, object f, object x, object y, object z, params object[] more) =>
            funclib.Core.Assoc(m, k, funclib.Core.Apply(f, funclib.Core.Get(m, k), x, y, z, more));
    }
}

using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    public abstract class ARef : 
        IRef
    {
        protected volatile IFunction _validator = null;

        volatile IMap _watches = (IMap)hashMap();

        #region Abstract Methods
        /// <summary>
        /// Returns the current state of <see cref="IDeref"/> variable.
        /// </summary>
        /// <returns>
        /// Returns the current state of <see cref="IDeref"/> variable.
        /// </returns>
        public abstract object Deref();
        #endregion

        #region Virtual Methods
        /// <summary>
        /// Sets the validator function for <see cref="IRef"/> variables. Validator 
        /// function must be null or a side-effect-free <see cref="IFunction"/> of
        /// one argument, which will be passed the intended new state of any state
        /// change. If the new state is unacceptable, the function should either
        /// return <see cref="false"/> or throw an exception.
        /// </summary>
        /// <param name="vf">>An object that implements the <see cref="IFunction"/> interface, that takes one parameter.</param>
        public virtual void SetValidator(IFunction vf)
        {
            Validate(vf, Deref());
            this._validator = vf;
        }
        #endregion

        protected internal void Validate(object val) => Validate(this._validator, val);

        /// <summary>
        /// Returns the current validator function, otherwise null.
        /// </summary>
        /// <returns>
        /// Returns the current validator function, otherwise null.
        /// </returns>
        public IFunction GetValidator() => this._validator;

        /// <summary>
        /// Returns all the watches currently setup for this <see cref="ARef"/>
        /// </summary>
        /// <returns></returns>
        public IMap GetWatches() => this._watches;

        /// <summary>
        /// Adds a watch function to an <see cref="IRef"/> variable. The
        /// watch function must implement the <see cref="IFunction"/> interface
        /// and take 4 arguments. The key, the reference, its old-state and its new
        /// state. Whenever the <see cref="IRef"/>'s state changes all registered
        /// watches will be called. The functions will be synchronously called. Note:
        /// an <see cref="IAtom"/>'s state may have changed prior to calling the 
        /// function so use th old/new state argument instead of deref'ing the 
        /// state again.
        /// </summary>
        /// <param name="key">A unique key for the function.</param>
        /// <param name="callback">An object that implements the <see cref="IFunction"/> interface and takes 4 arguments.</param>
        /// <returns>
        /// Returns this <see cref="ARef"/> object.
        /// </returns>
        public IRef AddWatch(object key, IFunction callback)
        {
            this._watches = this._watches.Assoc(key, callback);
            return this;
        }

        /// <summary>
        /// Removes a watch from the <see cref="ARef"/>'s reference.
        /// </summary>
        /// <param name="key">A unique key for the function to be removed.</param>
        /// <returns>
        /// Returns this <see cref="ARef"/> object.
        /// </returns>
        public IRef RemoveWatch(object key)
        {
            this._watches = this._watches.Without(key);
            return this;
        }

        /// <summary>
        /// Notifies all watches registered to the <see cref="ARef"/> variable.
        /// </summary>
        /// <param name="oldVal">The old state of the <see cref="ARef"/>.</param>
        /// <param name="newVal">The new state of the <see cref="ARef"/>.</param>
        public void NotifyWatches(object oldVal, object newVal)
        {
            var ws = this._watches;
            if (ws.Count > 0)
            {
                for (var s = ws.Seq(); s != null; s = s.Next())
                {
                    var kvp = (KeyValuePair)s.First();
                    if (!(kvp.Value is null))
                        invoke(kvp.Value, kvp.Key, this, oldVal, newVal);
                }
            }
        }

        protected internal static void Validate(IFunction vf, object val)
        {
            if (vf == null) return;
            bool ret = false;

            try
            {
                ret = (bool)boolean(invoke(vf, val));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid reference state.", ex);
            }

            if (!ret)
                throw new InvalidOperationException("Invalid reference state.");
        }
    }
}

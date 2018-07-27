using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates and returns an <see cref="Atom"/> with an initial value or x
    /// and zero or more options:
    ///     :validator = validate-fn
    /// Validate-fn must be nil or a side effect free <see cref="IFunction"/>
    /// of one argument. Which will be passed the intended new state on any
    /// state change. If the new state is unacceptable, the validate-fn should
    /// return false or throw an exception.
    /// </summary>
    public class Atom :
        ARef,
        IAtom,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        AtomicReference<object> _state;

        /// <summary>
        /// Creates a new <see cref="Atom"/> object.
        /// </summary>
        public Atom() { }

        Atom(object state)
        {
            this._state = new AtomicReference<object>(state);
        }

        #region Overrides
        /// <summary>
        /// Returns the current state of ref.
        /// </summary>
        /// <returns>
        /// Returns the current state of ref.
        /// </returns>
        public override object Deref() => this._state.Get();
        #endregion

        /// <summary>
        /// Atomically sets the value of the <see cref="IAtom"/>
        /// to the new value if and only if the current value of 
        /// the <see cref="IAtom"/> is identical to the oldVal.
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="oldVal">Current state of the atom.</param>
        /// <param name="newVal">New state of the atom after successful swap.</param>
        /// <returns>
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </returns>
        public bool CompareAndSet(object oldVal, object newVal)
        {
            Validate(newVal);
            bool ret = this._state.CompareAndSet(oldVal, newVal);
            if (ret)
                NotifyWatches(oldVal, newVal);
            return ret;
        }
        /// <summary>
        /// Sets the value of the <see cref="IAtom"/> to a new value. Returns
        /// <see cref="IVector"/> of the old, new, the value of the <see cref="IAtom"/>
        /// before and after the rest.
        /// </summary>
        /// <param name="newVal">New state of the atom after successful reset.</param>
        /// <returns>
        /// Returns <see cref="IVector"/> of the old, new, the value of the <see cref="IAtom"/>
        /// before and after the rest.
        /// </returns>
        public IVector Reset(object newVal)
        {
            Validate(newVal);
            for (; ; )
            {
                var oldVal = Deref();
                if (this._state.CompareAndSet(oldVal, newVal))
                {
                    NotifyWatches(oldVal, newVal);
                    return Collections.Vector.Create(oldVal, newVal);
                }
            }
        }

        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public IVector Swap(object f) => swap(oldVal => invoke(f, oldVal));
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public IVector Swap(object f, object x) => swap(oldVal => invoke(f, oldVal, x));
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public IVector Swap(object f, object x, object y) => swap(oldVal => invoke(f, oldVal, x, y));
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public IVector Swap(object f, object x, object y, params object[] args) => swap(oldVal => invoke(f, oldVal, x, y, args));

        IVector swap(Func<object, object> func)
        {
            for (; ; )
            {
                var oldVal = Deref();
                var newVal = func(oldVal);
                Validate(newVal);
                if (this._state.CompareAndSet(oldVal, newVal))
                {
                    NotifyWatches(oldVal, newVal);
                    return Collections.Vector.Create(oldVal, newVal);
                }
            }
        }

        /// <summary>
        /// Creates and returns an <see cref="Atom"/> with an initial value or x
        /// and zero or more options:
        ///     :validator = validate-fn
        /// Validate-fn must be nil or a side effect free <see cref="IFunction"/>
        /// of one argument. Which will be passed the intended new state on any
        /// state change. If the new state is unacceptable, the validate-fn should
        /// return false or throw an exception.
        /// </summary>
        /// <param name="x">Initial value of the <see cref="Atom"/>.</param>
        /// <returns>
        /// Returns a new <see cref="Atom"/> with the initial value set.
        /// </returns>
        public object Invoke(object x) => new Atom(x);
        /// <summary>
        /// Creates and returns an <see cref="Atom"/> with an initial value or x
        /// and zero or more options:
        ///     :validator = validate-fn
        /// Validate-fn must be nil or a side effect free <see cref="IFunction"/>
        /// of one argument. Which will be passed the intended new state on any
        /// state change. If the new state is unacceptable, the validate-fn should
        /// return false or throw an exception.
        /// </summary>
        /// <param name="x">Initial value of the <see cref="Atom"/>.</param>
        /// <param name="options">Key/Value pair of options. options are:
        ///     :validator = validate-fn
        /// </param>
        /// <returns>
        /// Returns a new <see cref="Atom"/> with the initial value set.
        /// </returns>
        public object Invoke(object x, params object[] options)
        {
            var r = new Atom(x);

            var opts = apply(funclib.core.HashMap, options);
            var validator = get(opts, ":validator", get(opts, "validator"));
            if (!(validator is null))
                r.SetValidator((IFunction)validator);

            return r;
        }

    }
}

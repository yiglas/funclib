using funclib.Collections;
using funclib.Exceptions;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Applies <see cref="IFunction"/> f to the argument list formed prepending 
    /// intervening arguments to args.
    /// </summary>
    public class Apply :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunction<object, object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object, object>
    {
        /// <summary>
        /// Applies <see cref="IFunction"/> f to the argument list formed perpending 
        /// intervening arguments to args.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="args">An object that can be <see cref="Seq"/> against for the arguments for f.</param>
        /// <returns>
        /// Returns the results of executing f with the given arguments.
        /// </returns>
        public object Invoke(object f, object args) => ApplyTo(f, seq(args));
        /// <summary>
        /// Applies <see cref="IFunction"/> f to the argument list formed perpending 
        /// intervening arguments to args.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First argument pass to f.</param>
        /// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
        /// <returns>
        /// Returns the results of executing f with the given arguments.
        /// </returns>
        public object Invoke(object f, object x, object args) => ApplyTo(f, listS(x, args));
        /// <summary>
        /// Applies <see cref="IFunction"/> f to the argument list formed perpending 
        /// intervening arguments to args.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First argument pass to f.</param>
        /// <param name="y">Second argument pass to f.</param>
        /// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
        /// <returns>
        /// Returns the results of executing f with the given arguments.
        /// </returns>
        public object Invoke(object f, object x, object y, object args) => ApplyTo(f, listS(x, y, args));
        /// <summary>
        /// Applies <see cref="IFunction"/> f to the argument list formed perpending 
        /// intervening arguments to args.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First argument pass to f.</param>
        /// <param name="y">Second argument pass to f.</param>
        /// <param name="z">Third argument passed to f.</param>
        /// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
        /// <returns>
        /// Returns the results of executing f with the given arguments.
        /// </returns>
        public object Invoke(object f, object x, object y, object z, object args) => ApplyTo(f, listS(x, y, z, args));
        /// <summary>
        /// Applies <see cref="IFunction"/> f to the argument list formed perpending 
        /// intervening arguments to args.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="a">First argument pass to f.</param>
        /// <param name="b">Second argument pass to f.</param>
        /// <param name="c">Third argument passed to f.</param>
        /// <param name="d">Fourth argument passed to f.</param>
        /// <param name="args">Rest of the arguments passed to f.</param>
        /// <returns>
        /// Returns the results of executing f with the given arguments.
        /// </returns>
        public object Invoke(object f, object a, object b, object c, object d, params object[] args) =>
            ApplyTo(f, cons(a, cons(b, cons(c, cons(d, spread(args))))));

        internal static object ApplyTo(object f, object args)
        {
            var cnt = (int)count(args);

            var fn = f.GetType()
                .GetInterfaces()
                .Where(x => x.IsGenericType)
                .Select(x => new { InterfaceType = x.GetGenericTypeDefinition(), ParameterCount = x.GenericTypeArguments.Count() })
                .Where(x => x.ParameterCount - 1  <= cnt)
                .OrderByDescending(x => x.ParameterCount)
                .FirstOrDefault();

            if (fn == null || (fn.ParameterCount - 1 < cnt && !(f is IFunctionParams)))
                throw new ArityException(cnt, f.GetType().FullName);

            return ApplyTo(fn.InterfaceType, f, (ISeq)args);
        }

        static object ApplyTo(Type interfaceType, object f, ISeq args) =>
            interfaceType == typeof(IFunction<>)
                ? ApplyTo((IFunction<object>)f)
                : interfaceType == typeof(IFunction<,>) ? ApplyTo((IFunction<object, object>)f, args)
                : interfaceType == typeof(IFunction<,,>) ? ApplyTo((IFunction<object, object, object>)f, args)
                : interfaceType == typeof(IFunction<,,,>) ? ApplyTo((IFunction<object, object, object, object>)f, args)
                : interfaceType == typeof(IFunction<,,,,>) ? ApplyTo((IFunction<object, object, object, object, object>)f, args)
                : interfaceType == typeof(IFunction<,,,,,>) ? ApplyTo((IFunction<object, object, object, object, object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,>) ? ApplyTo((IFunctionParams<object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,,>) ? ApplyTo((IFunctionParams<object, object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,,,>) ? ApplyTo((IFunctionParams<object, object, object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,,,,>) ? ApplyTo((IFunctionParams<object, object, object, object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,,,,,>) ? ApplyTo((IFunctionParams<object, object, object, object, object, object>)f, args)
                : interfaceType == typeof(IFunctionParams<,,,,,,>) ? ApplyTo((IFunctionParams<object, object, object, object, object, object, object>)f, args)
                : throw new ArityException(args.Count, f.GetType().FullName);


        static object ApplyTo(IFunction<object> f) => f.Invoke();
        static object ApplyTo(IFunction<object, object> f, ISeq args) => f.Invoke(Ret(args.First(), args = null));
        static object ApplyTo(IFunction<object, object, object> f, ISeq args) => 
            f.Invoke(
                args.First(), 
                Ret((args = args.Next()).First(), args = null));
        static object ApplyTo(IFunction<object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                Ret((args = args.Next()).First(), args = null));
        static object ApplyTo(IFunction<object, object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                Ret((args = args.Next()).First(), args = null));
        static object ApplyTo(IFunction<object, object, object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                Ret((args = args.Next()).First(), args = null));
        static object ApplyTo(IFunctionParams<object, object> f, ISeq args) =>
            //f.Invoke((object[])toArray(Ret(args.First(), args = null)));
            f.Invoke(Ret(args.First(), args = null));
        static object ApplyTo(IFunctionParams<object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(), 
                (object[])toArray(Ret((args = args.Next()), args = null)));
        static object ApplyTo(IFunctionParams<object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (object[])toArray(Ret((args = args.Next()), args = null)));
        static object ApplyTo(IFunctionParams<object, object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (object[])toArray(Ret((args = args.Next()), args = null)));
        static object ApplyTo(IFunctionParams<object, object, object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (object[])toArray(Ret((args = args.Next()), args = null)));
        static object ApplyTo(IFunctionParams<object, object, object, object, object, object, object> f, ISeq args) =>
            f.Invoke(
                args.First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (args = args.Next()).First(),
                (object[])toArray(Ret((args = args.Next()), args = null)));

        public static object Ret(object ret, object nullable) => ret;
    }
}

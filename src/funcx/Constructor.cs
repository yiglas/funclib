namespace funcx
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection.Emit;

    /// <summary>
    /// Quicker way to create new objects
    /// </summary>
    public class Constructor
    {
        /// <summary>
        /// Constructor delegate.
        /// </summary>
        public delegate T ConstructorDelegate<T>(params object[] args);

        /// <summary>
        /// Creates the constructor.
        /// </summary>
        /// <returns>The constructor.</returns>
        /// <param name="parameters">Parameters.</param>
        /// <typeparam name="TClass">The 1st type parameter.</typeparam>
        public ConstructorDelegate<TClass> CreateConstructor<TClass>(params Type[] parameters)
        {
            var ctor = typeof(TClass).GetConstructor(parameters);
            var expr = Expression.Parameter(typeof(Object[]));
            var parms = parameters.Select((paramType, index) =>
                // convert the object[index] to the right constructor parameter type.
                Expression.Convert(
                    // read a value from the object[index]
                    Expression.ArrayAccess(expr,
                    Expression.Constant(index)),
                paramType)).ToArray();
            var body = Expression.New(ctor, parms);
            var constructor = Expression.Lambda<ConstructorDelegate<TClass>>(body, expr);
            return constructor.Compile();
        }
    }
}

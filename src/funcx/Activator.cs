//namespace funcx
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using System.Reflection.Emit;
//    using System.Text;

//    /// <summary>
//    /// Contains methods to create types of objects using Expressions.
//    /// </summary>
//    public static class Activator
//    {
//        /// <summary>
//        /// Creates a System.Linq.Expressions.LambdaExpression by first constructing a delegate type.
//        /// </summary>
//        /// <typeparam name="T">The type of the object to create</typeparam>
//        /// <param name="args">An array of arguments that match in number, order and type the parameters of 
//        /// the constructor to invoke. If args is an empty array or null, the constructor 
//        /// that takes no parameters (the default constructor) is invoked.</param>
//        /// A reference to the newly created object.</param>
//        /// <returns>An object that represents a lambda expression.</returns>
//        public delegate T ConstructorDelegate<T>(params object[] args);

//        /// <summary>
//        /// Creates a System.Linq.Expressions.LambdaExpression by first constructing a delegate type.
//        /// </summary>
//        /// <param name="args">An array of arguments that match in number, order and type the parameters of 
//        /// the constructor to invoke. If args is an empty array or null, the constructor 
//        /// that takes no parameters (the default constructor) is invoked.</param>
//        /// A reference to the newly created object.</param>
//        /// <returns>An object that represents a lambda expression.</returns>
//        public delegate object ConstructorDelegate(params object[] args);

//        /// <summary>
//        /// Creates an instance of the specified type using the constructor that best matches
//        /// the specified parameters.
//        /// </summary>
//        /// <typeparam name="TClass">The type of the object to create</typeparam>
//        /// <param name="args">An array of arguments that match in number, order and type the parameters of 
//        /// the constructor to invoke. If args is an empty array or null, the constructor 
//        /// that takes no parameters (the default constructor) is invoked.</param>
//        /// <returns>A reference to the newly created object.</returns>
//        public static ConstructorDelegate<TClass> CreateInstance<TClass>(params Type[] args)
//        {
//            //Type t = typeof(TClass);
//            //var ctor = t.GetConstructor(args);
//            //string methodName = t.Name + "Ctor";
//            //var dm = new DynamicMethod(methodName, t, args, typeof(System.Activator));
//            //var gen = dm.GetILGenerator();
//            //gen.Emit(OpCodes.Newobj, ctor);
//            //gen.Emit(OpCodes.Ret);

//            //var creator = (ConstructorDelegate<TClass>)dm.CreateDelegate(typeof(ConstructorDelegate<TClass>));

//            //return creator;

//            var ctor = typeof(TClass).GetConstructor(args);
//            var expr = Expression.Parameter(typeof(Object[]));
//            var parms = args.Select((paramType, index) =>
//                // convert the object[index] to the right constructor parameter type.
//                Expression.Convert(
//                    // read a value from the object[index]
//                    Expression.ArrayAccess(expr, Expression.Constant(index)),
//                    paramType)).ToArray();
//            var body = Expression.New(ctor, parms);
//            var constructor = Expression.Lambda<ConstructorDelegate<TClass>>(body, expr);
//            return constructor.Compile();
//        }

//        /// <summary>
//        /// Creates an instance of the specified type using the constructor that best matches
//        /// the specified parameters.
//        /// </summary>
//        /// <param name="type">The type of the object to create</param>
//        /// <param name="args">An array of arguments that match in number, order and type the parameters of 
//        /// the constructor to invoke. If args is an empty array or null, the constructor 
//        /// that takes no parameters (the default constructor) is invoked.</param>
//        /// <returns>A reference to the newly created object.</returns>
//        public static ConstructorDelegate CreateInstance(Type type, params Type[] args)
//        {
//            var ctor = type.GetConstructor(args);
//            var expr = Expression.Parameter(typeof(Object[]));
//            var parms = args.Select((paramType, index) =>
//                // convert the object[index] to the right constructor parameter type.
//                Expression.Convert(
//                    // read a value from the object[index]
//                    Expression.ArrayAccess(expr, Expression.Constant(index)),
//                    paramType)).ToArray();
//            var body = Expression.New(ctor, parms);
//            var constructor = Expression.Lambda<ConstructorDelegate>(body, expr);
//            return constructor.Compile();
//        }
//    }
//}

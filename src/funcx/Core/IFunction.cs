using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public interface IFunction
    {
        // empty
    }

    public interface IFunctionParams : IFunction
    {
        // empty
    }
    
    public interface IFunction<TResult> : IFunction
    {
        TResult Invoke();
    }

    public interface IFunction<T1, TResult> : IFunction
    {
        TResult Invoke(T1 arg1);
    }

    public interface IFunction<T1, T2, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2);
    }

    public interface IFunction<T1, T2, T3, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3);
    }

    public interface IFunction<T1, T2, T3, T4, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    public interface IFunction<T1, T2, T3, T4, T5, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }



    public interface IFunctionParams<TRest, TResult> : IFunctionParams
    {
        TResult Invoke(params TRest[] rest);
    }

    public interface IFunctionParams<T1, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, params TRest[] rest);
    }

    public interface IFunctionParams<T1, T2, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, params TRest[] rest);
    }

    public interface IFunctionParams<T1, T2, T3, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, params TRest[] rest);
    }

    public interface IFunctionParams<T1, T2, T3, T4, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, params TRest[] rest);
    }

    public interface IFunctionParams<T1, T2, T3, T4, T5, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, params TRest[] rest);
    }
}

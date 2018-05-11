namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static TResult @try<TResult>(Func<TResult> expr)
        {
            try
            {
                return expr();
            }
            catch
            {
                return default;
            }
        }

        public static TResult @try<TResult>(Func<TResult> expr, Func<TResult> @catch, Action @finally = null)
        {
            try
            {
                return expr();
            }
            catch
            {
                return @catch();
            }
            finally
            {
                @finally?.Invoke();
            }
        }

        public static TResult @try<TResult>(Func<TResult> expr, IEnumerable<(Exception, Func<TResult>)> @catch, Action @finally = null)
        {
            try
            {
                return expr();
            }
            catch (Exception ex)
            {
                var (_, f) = @catch.FirstOrDefault(((Exception e, Func<TResult> f) x) => x.e.GetType() == ex.GetType());
                if (f != null)
                    return f();

                return default;
            }
            finally
            {
                @finally?.Invoke();
            }
        }
    }
}

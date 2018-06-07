using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace FunctionalLibrary.Exceptions
{
    public class ArityException : Exception
    {
        public int Actual { get; }
        public string MethodName { get; }

        public ArityException([CallerMemberName] string methodName = "") :
            this(-1, methodName)
        { }

        public ArityException(string message, [CallerMemberName] string methodName = "") :
            this(-1, message, methodName)
        { }

        public ArityException(int actual, [CallerMemberName] string methodName = "") :
            this(actual, $"Wrong number of args ({actual}) passed to {methodName}.", methodName)
        { }

        public ArityException(int actual, string message, [CallerMemberName] string methodName = "") :
            base (message)
        {
            Actual = actual;
            MethodName = methodName;
        }

        #region Overrides
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            base.GetObjectData(info, context);
            info.AddValue("Actual", Actual, typeof(int));
            info.AddValue("MethodName", MethodName, typeof(string));
        }
        #endregion
    }
}

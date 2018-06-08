using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FunctionalLibrary
{
    static class Numbers
    {
        static IOperations Operation(object x)
        {
            Type type = x.GetType();

            if (type == typeof(double) || type == typeof(float)) return new DoubleOperations(x);

            return new LongOperations(x);
        }

        internal static object Inc(object x) => Operation(x).Inc();
        internal static object Dec(object x) => Operation(x).Dec();
        internal static bool IsZero(object x) => Operation(x).IsZero();
        internal static bool IsPos(object x) => Operation(x).IsPos();
        internal static bool IsNeg(object x) => Operation(x).IsNeg();
        internal static object Add(object x, object y) => Operation(x).Combine(Operation(y)).Add(y);
        internal static object Subtract(object x, object y) => Operation(x).Combine(Operation(y)).Subtract(y);
        internal static object Multiply(object x, object y) => Operation(x).Combine(Operation(y)).Multiply(y);
        internal static object Divide(object x, object y) => Operation(x).Combine(Operation(y)).Divide(y);
        internal static bool IsLT(object x, object y) => Operation(x).Combine(Operation(y)).IsLT(y);
        internal static bool IsLTE(object x, object y) => Operation(x).Combine(Operation(y)).IsLTE(y);
        internal static bool IsGT(object x, object y) => Operation(x).Combine(Operation(y)).IsGT(y);
        internal static bool IsGTE(object x, object y) => Operation(x).Combine(Operation(y)).IsGTE(y);
        internal static bool IsEqual(object x, object y) => Operation(x).Combine(Operation(y)).IsEqual(y);

        internal static bool IsNumber(object o) => o != null && IsNumber(o.GetType());
        internal static bool IsNumber(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }

            return false;
        }
        internal static int Compare(object x, object y)
        {
            var xyops = Operation(x).Combine(Operation(y));
            if (xyops.IsLT(y)) return -1;
            else if (xyops.IsGT(y)) return 1;
            else return 0;
        }


        interface IOperations
        {
            IOperations Combine(IOperations y);
            IOperations OperationWith(LongOperations x);
            IOperations OperationWith(DoubleOperations x);

            bool IsZero();
            bool IsPos();
            bool IsNeg();
            object Inc();
            object Dec();
            object Negate();

            object Add(object y);
            object Subtract(object y);
            object Multiply(object y);
            object Divide(object y);

            bool IsEqual(object y);
            bool IsLT(object y);
            bool IsLTE(object y);
            bool IsGT(object y);
            bool IsGTE(object y);
        }

        sealed class LongOperations : IOperations
        {
            long _value;

            public LongOperations(object x)
            {
                this._value = ConvertToLong(x);
            }

            public override int GetHashCode() => this._value.GetHashCode();
            public override bool Equals(object obj) => this == obj;
            public override string ToString() => this._value.ToString();

            public IOperations Combine(IOperations y) => y.OperationWith(this);
            public IOperations OperationWith(LongOperations x) => this;
            public IOperations OperationWith(DoubleOperations x) => new DoubleOperations(this._value);

            public object Dec() => this._value - 1;
            public object Inc() => this._value + 1;
            public bool IsNeg() => this._value < 0;
            public bool IsPos() => this._value > 0;
            public bool IsZero() => this._value == 0;

            public object Negate() => -this._value;
            public object Add(object y) => this._value + ConvertToLong(y);
            public object Subtract(object y) => this._value - ConvertToLong(y);
            public object Multiply(object y) => this._value * ConvertToLong(y);
            public object Divide(object y) => this._value / ConvertToLong(y);

            public bool IsEqual(object y) => this._value == ConvertToLong(y);
            public bool IsLT(object y) => this._value < ConvertToLong(y);
            public bool IsLTE(object y) => this._value <= ConvertToLong(y);
            public bool IsGT(object y) => this._value > ConvertToLong(y);
            public bool IsGTE(object y) => this._value >= ConvertToLong(y);
        }

        sealed class DoubleOperations : IOperations
        {
            double _value;

            public DoubleOperations(object x)
            {
                this._value = ConvertToDouble(x);
            }

            public override int GetHashCode() => this._value.GetHashCode();
            public override bool Equals(object obj) => this == obj;
            public override string ToString() => this._value.ToString();

            public IOperations Combine(IOperations y) => y.OperationWith(this);
            public IOperations OperationWith(LongOperations x) => this;
            public IOperations OperationWith(DoubleOperations x) => this;

            public object Dec() => this._value - 1;
            public object Inc() => this._value + 1;
            public bool IsNeg() => this._value < 0;
            public bool IsPos() => this._value > 0;
            public bool IsZero() => this._value == 0;
            public object Negate() => -this._value;

            public object Add(object y) => this._value + ConvertToDouble(y);
            public object Subtract(object y) => this._value - ConvertToDouble(y);
            public object Multiply(object y) => this._value * ConvertToDouble(y);
            public object Divide(object y) => this._value / ConvertToDouble(y);

            public bool IsEqual(object y) => this._value == ConvertToDouble(y);
            public bool IsLT(object y) => this._value < ConvertToDouble(y);
            public bool IsLTE(object y) => this._value <= ConvertToDouble(y);
            public bool IsGT(object y) => this._value > ConvertToDouble(y);
            public bool IsGTE(object y) => this._value >= ConvertToDouble(y);
        }

        internal static long ConvertToLong(object x)
        {
            switch (Type.GetTypeCode(x.GetType()))
            {
                case TypeCode.Byte: return (byte)x;
                case TypeCode.Char: return (char)x;
                case TypeCode.Decimal: return (long)(decimal)x;
                case TypeCode.Double: return (long)(double)x;
                case TypeCode.Int16: return (short)x;
                case TypeCode.Int32: return (int)x;
                case TypeCode.Int64: return (long)x;
                case TypeCode.SByte: return (sbyte)x;
                case TypeCode.Single: return (long)(float)x;
                case TypeCode.UInt16: return (ushort)x;
                case TypeCode.UInt32: return (uint)x;
                case TypeCode.UInt64: return (long)(ulong)x;
                default:
                    return Convert.ToInt64(x, CultureInfo.InvariantCulture);
            }
        }

        internal static double ConvertToDouble(object x)
        {
            switch (Type.GetTypeCode(x.GetType()))
            {
                case TypeCode.Byte: return (byte)x;
                case TypeCode.Char: return (char)x;
                case TypeCode.Decimal: return (double)(decimal)x;
                case TypeCode.Double: return (double)x;
                case TypeCode.Int16: return (short)x;
                case TypeCode.Int32: return (int)x;
                case TypeCode.Int64: return (long)x;
                case TypeCode.SByte: return (sbyte)x;
                case TypeCode.Single: return (float)x;
                case TypeCode.UInt16: return (ushort)x;
                case TypeCode.UInt32: return (uint)x;
                case TypeCode.UInt64: return (ulong)x;
                default:
                    return Convert.ToDouble(x, CultureInfo.InvariantCulture);
            }
        }

        internal static int ConvertToInt(object x)
        {
            switch (Type.GetTypeCode(x.GetType()))
            {
                case TypeCode.Byte: return (byte)x;
                case TypeCode.Char: return (char)x;
                case TypeCode.Decimal: return (int)(decimal)x;
                case TypeCode.Double: return (int)(double)x;
                case TypeCode.Int16: return (short)x;
                case TypeCode.Int32: return (int)x;
                case TypeCode.Int64: return (int)(long)x;
                case TypeCode.SByte: return (sbyte)x;
                case TypeCode.Single: return (int)(float)x;
                case TypeCode.UInt16: return (ushort)x;
                case TypeCode.UInt32: return (int)(uint)x;
                case TypeCode.UInt64: return (int)(ulong)x;
                default:
                    return Convert.ToInt32(x, CultureInfo.InvariantCulture);
            }
        }
    }
}

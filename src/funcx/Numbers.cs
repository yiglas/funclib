using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FunctionalLibrary
{
    static class Numbers
    {
        static readonly LongOperations LONG = new LongOperations();
        static readonly DoubleOperations DOUBLE = new DoubleOperations();

        static IOperations Operation(object x)
        {
            Type type = x.GetType();

            if (type == typeof(double) || type == typeof(float)) return DOUBLE;

            return LONG;
        }

        internal static object Inc(object x) => Operation(x).Inc(x);
        internal static object Dec(object x) => Operation(x).Dec(x);
        internal static bool IsZero(object x) => Operation(x).IsZero(x);
        internal static bool IsPos(object x) => Operation(x).IsPos(x);
        internal static bool IsNeg(object x) => Operation(x).IsNeg(x);
        internal static object Negate(object x) => Operation(x).Negate(x);
        internal static object Add(object x, object y) => Operation(x).Combine(Operation(y)).Add(x, y);
        internal static object Subtract(object x, object y) => Operation(x).Combine(Operation(y)).Subtract(x, y);
        internal static object Multiply(object x, object y) => Operation(x).Combine(Operation(y)).Multiply(x, y);
        internal static object Divide(object x, object y) => Operation(x).Combine(Operation(y)).Divide(x, y);
        internal static bool IsLT(object x, object y) => Operation(x).Combine(Operation(y)).IsLT(x, y);
        internal static bool IsLTE(object x, object y) => Operation(x).Combine(Operation(y)).IsLTE(x, y);
        internal static bool IsGT(object x, object y) => Operation(x).Combine(Operation(y)).IsGT(x, y);
        internal static bool IsGTE(object x, object y) => Operation(x).Combine(Operation(y)).IsGTE(x, y);
        internal static bool IsEqual(object x, object y) => Operation(x).Combine(Operation(y)).IsEqual(x, y);

        internal static object Not(object x) => ~BitOperationCast(x);
        internal static object And(object x, object y) => BitOperationCast(x) & BitOperationCast(y);
        internal static object AndNot(object x, object y) => BitOperationCast(x) & ~BitOperationCast(y);
        internal static object Or(object x, object y) => BitOperationCast(x) | BitOperationCast(y);
        internal static object XOr(object x, object y) => BitOperationCast(x) ^ BitOperationCast(y);
        internal static object ClearBit(object x, object y) => BitOperationCast(x) & (1L << (int)BitOperationCast(y));
        internal static object SetBit(object x, object y) => BitOperationCast(x) | (1L << (int)BitOperationCast(y));
        internal static object FlipBit(object x, object y) => BitOperationCast(x) ^ (1L << (int)BitOperationCast(y));
        internal static object TestBit(object x, object y) => (BitOperationCast(x) & (1L << (int)BitOperationCast(y))) != 0;
        internal static object ShiftLeft(object x, object y) => BitOperationCast(x) << (int)BitOperationCast(y);
        internal static object ShiftRight(object x, object y) => BitOperationCast(x) >> (int)BitOperationCast(y);
        internal static object UnsignedShiftRight(object x, object y) => (long)((ulong)BitOperationCast(x) >> (int)BitOperationCast(y));

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
            if (xyops.IsLT(x, y)) return -1;
            else if (xyops.IsGT(x, y)) return 1;
            else return 0;
        }


        interface IOperations
        {
            IOperations Combine(IOperations y);
            IOperations OperationWith(LongOperations x);
            IOperations OperationWith(DoubleOperations x);

            bool IsZero(object x);
            bool IsPos(object x);
            bool IsNeg(object x);
            object Inc(object x);
            object Dec(object x);
            object Negate(object x);

            object Add(object x, object y);
            object Subtract(object x, object y);
            object Multiply(object x, object y);
            object Divide(object x, object y);

            bool IsEqual(object x, object y);
            bool IsLT(object x, object y);
            bool IsLTE(object x, object y);
            bool IsGT(object x, object y);
            bool IsGTE(object x, object y);
        }

        sealed class LongOperations : IOperations
        {
            public IOperations Combine(IOperations y) => y.OperationWith(this);
            public IOperations OperationWith(LongOperations x) => this;
            public IOperations OperationWith(DoubleOperations x) => DOUBLE;

            public object Dec(object x) => ConvertToLong(x) - 1;
            public object Inc(object x) => ConvertToLong(x) + 1;
            public bool IsNeg(object x) => ConvertToLong(x) < 0;
            public bool IsPos(object x) => ConvertToLong(x) > 0;
            public bool IsZero(object x) => ConvertToLong(x) == 0;

            public object Negate(object x) => -ConvertToLong(x);
            public object Add(object x, object y) => ConvertToLong(x) + ConvertToLong(y);
            public object Subtract(object x, object y) => ConvertToLong(x) - ConvertToLong(y);
            public object Multiply(object x, object y) => ConvertToLong(x) * ConvertToLong(y);
            public object Divide(object x, object y) => ConvertToLong(x) / ConvertToLong(y);

            public bool IsEqual(object x, object y) => ConvertToLong(x) == ConvertToLong(y);
            public bool IsLT(object x, object y) => ConvertToLong(x) < ConvertToLong(y);
            public bool IsLTE(object x, object y) => ConvertToLong(x) <= ConvertToLong(y);
            public bool IsGT(object x, object y) => ConvertToLong(x) > ConvertToLong(y);
            public bool IsGTE(object x, object y) => ConvertToLong(x) >= ConvertToLong(y);
        }

        sealed class DoubleOperations : IOperations
        {
            public IOperations Combine(IOperations y) => y.OperationWith(this);
            public IOperations OperationWith(LongOperations x) => this;
            public IOperations OperationWith(DoubleOperations x) => this;

            public object Dec(object x) => ConvertToDouble(x) - 1;
            public object Inc(object x) => ConvertToDouble(x) + 1;
            public bool IsNeg(object x) => ConvertToDouble(x) < 0;
            public bool IsPos(object x) => ConvertToDouble(x) > 0;
            public bool IsZero(object x) => ConvertToDouble(x) == 0;

            public object Negate(object x) => -ConvertToDouble(x);
            public object Add(object x, object y) => ConvertToDouble(x) + ConvertToDouble(y);
            public object Subtract(object x, object y) => ConvertToDouble(x) - ConvertToDouble(y);
            public object Multiply(object x, object y) => ConvertToDouble(x) * ConvertToDouble(y);
            public object Divide(object x, object y) => ConvertToDouble(x) / ConvertToDouble(y);

            public bool IsEqual(object x, object y) => ConvertToDouble(x) == ConvertToDouble(y);
            public bool IsLT(object x, object y) => ConvertToDouble(x) < ConvertToDouble(y);
            public bool IsLTE(object x, object y) => ConvertToDouble(x) <= ConvertToDouble(y);
            public bool IsGT(object x, object y) => ConvertToDouble(x) > ConvertToDouble(y);
            public bool IsGTE(object x, object y) => ConvertToDouble(x) >= ConvertToDouble(y);
        }

        internal static long ConvertToLong(object x)
        {
            try
            {
                switch (x)
                {
                    case byte b: return b;
                    case char c: return c;
                    case decimal m: return (long)m;
                    case double d: return (long)d;
                    case int i: return i;
                    case short s: return s;
                    case long l: return l;
                    case float f: return (long)f;
                    case uint ui: return ui;
                    case ushort us: return us;
                    case ulong ul: return (long)ul;
                    case sbyte sb: return sb;
                    default:
                        return Convert.ToInt64(x, CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{x.GetType().FullName} cannot be casted to Number.");
            }
        }

        internal static double ConvertToDouble(object x)
        {
            try
            {
                switch (x)
                {
                    case byte b: return b;
                    case char c: return c;
                    case decimal m: return (double)m;
                    case double d: return d;
                    case int i: return i;
                    case short s: return s;
                    case long l: return l;
                    case float f: return f;
                    case uint ui: return ui;
                    case ushort us: return us;
                    case ulong ul: return ul;
                    case sbyte sb: return sb;
                    default:
                        return Convert.ToDouble(x, CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{x.GetType().FullName} cannot be casted to Number.");
            }
}

        internal static int ConvertToInt(object x)
        {
            try
            {
                switch (x)
                {
                    case byte b: return b;
                    case char c: return c;
                    case decimal m: return (int)m;
                    case double d: return (int)d;
                    case int i: return i;
                    case short s: return s;
                    case long l: return (int)l;
                    case float f: return (int)f;
                    case uint ui: return (int)ui;
                    case ushort us: return us;
                    case ulong ul: return (int)ul;
                    case sbyte sb: return sb;
                    default:
                        return Convert.ToInt32(x, CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{x.GetType().FullName} cannot be casted to Number.");
            }
        }

        static long BitOperationCast(object x)
        {
            Type xt = x.GetType();
            if (xt == typeof(long)
                || xt == typeof(int)
                || xt == typeof(short)
                || xt == typeof(byte)
                || xt == typeof(ulong)
                || xt == typeof(uint)
                || xt == typeof(ushort)
                || xt == typeof(sbyte)) return ConvertToLong(x);

            throw new ArgumentException($"Bit operations are not supported for type {xt}");
        }
    }
}

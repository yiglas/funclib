using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FunctionalLibrary
{
    public struct Number
    {
        Number(object x)
        {
            IsValid = Double.TryParse(
                Convert.ToString(x, CultureInfo.InvariantCulture), 
                NumberStyles.Any, 
                NumberFormatInfo.InvariantInfo, 
                out double value);

            Value = value;
        }

        public static Number Create(object x) => new Number(x);

        public bool IsValid { get; }
        public double Value { get; }

        public static bool operator ==(Number a, Number b) =>
            a.IsValid && b.IsValid
                ? a.Value == b.Value
                : false;
        public static bool operator !=(Number a, Number b) => !(a == b);


        public static bool IsNumber(object x) => new Number(x).IsValid;
        public static bool IsEqual(object x, object y)
        {
            var n1 = new Number(x);
            var n2 = new Number(y);

            return n1 == n2;
        }
        public static int Compare(object x, object y)
        {
            var n1 = new Number(x);
            var n2 = new Number(y);

            if (n1.Value > n2.Value) return 1;
            if (n1.Value < n2.Value) return -1;
            return 0;
        }


    }
}

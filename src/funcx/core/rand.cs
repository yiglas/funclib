namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        static Random _random = new Random();

        public static double rand()
        {
            lock (_random)
            {
                return _random.NextDouble();
            }
        }

        public static double rand(double n) => n * rand();
    }
}

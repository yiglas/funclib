using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace funclib
{
    public static class Variables
    {
        public static TextWriter _out = Console.Out;
        public static TextWriter Out
        {
            get => _out;
            set
            {
                if (value != null)
                    _out = value;
            }
        }


        public static TextWriter _err = Console.Error;
        public static TextWriter Err
        {
            get => _err;
            set
            {
                if (value != null)
                    _err = value;
            }
        }

        public static TextReader _in = Console.In;
        public static TextReader In
        {
            get => _in;
            set
            {
                if (value != null)
                    _in = value;
            }
        }

        public static int _printLevel;
    }
}

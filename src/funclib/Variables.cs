using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace funclib
{
    public static class Variables
    {
        static TextWriter _out = Console.Out;
        public static TextWriter Out
        {
            get => _out;
            set
            {
                if (value != null)
                    _out = value;
            }
        }


        static TextWriter _err = Console.Error;
        public static TextWriter Err
        {
            get => _err;
            set
            {
                if (value != null)
                    _err = value;
            }
        }

        static TextReader _in = Console.In;
        public static TextReader In
        {
            get => _in;
            set
            {
                if (value != null)
                    _in = value;
            }
        }

        static int _printLevel;
    }
}

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace reverseshufflemerge
{
    class Solution
    {


        static void Main(string[] args)
        {
            String filename = args[0];
            var f = File.Open(filename, FileMode.Open, FileAccess.Read);
            TextReader tr = new StreamReader(f);
            //TextReader tr = Console.In; // new StreamReader(f);

            TextWriter textWriter = Console.Out; // new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = tr.ReadLine();

            string result = ReverseShuffleMerge.reverseShuffleMerge(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.InterpolatedVerbatimString
{
    public class InterpolatedVerbatimStringExamples
    {
        public static void Run()
        {
            Console.WriteLine("Verbatim String Interpolation");

            const string userName = "Sean";
            Console.WriteLine(@$"C:\User\{userName}\Documents\");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.UsingDeclarations
{
    internal class Resource : IDisposable
    {
        public Resource()
        {
            Console.WriteLine("Resource created...");
        }
        public void Dispose()
        {
            Console.WriteLine("Resource disposed..");
        }
    }

    public class UsingDeclarationsExamples
    {
        public static void Run()
        {
            Console.WriteLine("Using Declarations");
            using var resource = new Resource();

            // old way
            //using (var resource2 = new Resource())
            //{

            //}
        }
    }
}

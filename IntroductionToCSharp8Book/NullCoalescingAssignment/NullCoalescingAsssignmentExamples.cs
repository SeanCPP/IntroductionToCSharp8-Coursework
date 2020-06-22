using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.NullCoalescingAssignment
{
    internal class Singleton
    {
        private Singleton() { }
        private static Singleton instance;
        
        public static Singleton Get()
        {
            return instance ??= new Singleton();
        }

        public void Foo()
        {
            Console.WriteLine("Singleton instance!");
        }
    }
    public class NullCoalescingAsssignmentExamples
    {
        public static void Run()
        {
            Console.WriteLine("Null Coalescing Assignment");
            Singleton.Get().Foo();
        }
    }
}

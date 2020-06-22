using IntroductionToCSharp8Book.AsyncStreams;
using IntroductionToCSharp8Book.DefaultInterfaceImpl;
using IntroductionToCSharp8Book.InterpolatedVerbatimString;
using IntroductionToCSharp8Book.NullCoalescingAssignment;
using IntroductionToCSharp8Book.PatternMatching;
using IntroductionToCSharp8Book.RangesAndIndices;
using IntroductionToCSharp8Book.UsingDeclarations;
using System;

namespace IntroductionToCSharp8Book
{
    class Program
    {
        static void DefaultInterfaceImplExample(IInputOutput io)
        {
            io.PrintLn("Hello World");
        }
        static void AsyncStreamsExample()
        {
            Example.Run();
        }
        static void Main(string[] args)
        {
            //DefaultInterfaceImplExample(new ConsoleIO());
            //AsyncStreamsExample();
            RangeAndIndicesExamples.Run();
            Console.WriteLine();
            PatternMatchingExamples.Run();
            Console.WriteLine();

            UsingDeclarationsExamples.Run();
            Console.WriteLine();

            InterpolatedVerbatimStringExamples.Run();
            Console.WriteLine();

            NullCoalescingAsssignmentExamples.Run();
            Console.WriteLine();

        }
    }
}

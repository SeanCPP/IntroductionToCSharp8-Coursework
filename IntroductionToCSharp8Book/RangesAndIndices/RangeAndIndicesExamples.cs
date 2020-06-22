using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.RangesAndIndices
{
    public class RangeAndIndicesExamples
    {
        static readonly string[] names =
        {
            "Smith", "Jones", "Finn", "MacDonald",
        };
        static List<Action> Examples = new List<Action>
        {
            new Action(() =>
            {
                // ^ (hat) operator denotes index starting from the back
                Console.WriteLine(names[^1]);
            }),
            new Action(() =>
            {
                // .. denotes range between values
                foreach(var name in names[1..3])
                {
                    Console.WriteLine(name);
                }
            }),
            new Action(() =>
            {
                foreach(var name in names[..^1])
                {
                    Console.WriteLine(name);
                }
            }),
            new Action(() =>
            {
                var input = "5556552727";
                var PhoneNumber = new
                {
                    AreaCode = input[..3],
                    Digits = input[3..]
                };
                Console.WriteLine($"({PhoneNumber.AreaCode}) {PhoneNumber.Digits[0..3]} - {PhoneNumber.Digits[3..]}");
            }),
        };
        public static void Run()
        {
            Console.WriteLine("Ranges And Indices");

            int exampleNum = 1;
            foreach(var example in Examples)
            {
                Console.WriteLine($"Example {exampleNum}");
                example();
                Console.WriteLine();
                ++exampleNum;
            }
        }
    }
}

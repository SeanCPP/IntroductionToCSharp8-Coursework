using IntroductionToCSharp8Book.PatternMatching.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Cache;
using System.Reflection.Metadata;
using System.Text;

namespace IntroductionToCSharp8Book.PatternMatching
{
    using Example = Action;
    public class PatternMatchingExamples
    {
        enum TransactionType { Withdraw, Deposit };
        class TransactionResult
        {
            public TransactionType Type { get; set; }
        }
        private static readonly List<Example> Examples = new List<Action>
        {
            new Example(() => 
            {
                var user = new PersonModel{ Name="Sean", Age=25 };
                
                // Deconstructing an object
                var (name, age) = user;
                Console.WriteLine($"{name}, age {age}");
            }),
            new Example(() =>
            {
                // pattern matching with switch-expressions
                TransactionResult Transact(decimal amount) => amount switch
                {
                    decimal amt when amt > 0.0m
                        => new TransactionResult{ Type = TransactionType.Deposit },
                    decimal amt => new TransactionResult{ Type = TransactionType.Withdraw }
                };

                decimal amount = 4.0m;
                Console.WriteLine($"Transacting ${amount}. Resulting type is {Transact(amount).Type}");
                Console.WriteLine($"Transacting ${-amount}. Resulting type is {Transact(-amount).Type}");

            }),
            new Example(() =>
            {
                var user = new PersonModel {Name = "Smith", Age = 18};

                // only run commericals involving alcohol, if the user is 21+
                var adResult = user switch 
                {
                    PersonModel p when p.Age >= 21 => "21+ Ad Goes Here",
                    _ => "Default Ad"
                };
                Console.WriteLine($"Sending Ad to {user.Name}:\n{adResult}");
            }),
            new Example(() => 
            {
                // This only works because PersonModel has a Deconstruct method.
                var employee = (Name: "Beef Wellington", Age: 21);
                switch (employee)
                {
                    case (_, 21):
                        Console.WriteLine($"{employee.Name} is now 21!");
                        break;
                    case (_,_):
                        break;
                }
            }),
        };
        public static void Run()
        {
            Console.WriteLine("Pattern Matching");

            int exampleNum = 1;
            foreach (var example in Examples)
            {
                Console.WriteLine($"Example {exampleNum}");
                example();
                Console.WriteLine();
                ++exampleNum;
            }
        }
    }
}

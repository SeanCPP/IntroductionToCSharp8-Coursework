using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.PatternMatching.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }
}

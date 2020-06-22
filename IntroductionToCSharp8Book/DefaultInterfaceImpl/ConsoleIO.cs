using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.DefaultInterfaceImpl
{
    public class ConsoleIO : IInputOutput
    {
        public void Print(string text)
        {
            Console.Write(text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToCSharp8Book.DefaultInterfaceImpl
{
    public interface IInputOutput
    {
        void Print(string text);
        void PrintLn(string text)
        {
            Print($"{text}\n");
        }
    }
}

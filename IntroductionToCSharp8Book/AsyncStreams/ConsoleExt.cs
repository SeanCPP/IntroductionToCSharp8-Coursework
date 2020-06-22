using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToCSharp8Book.AsyncStreams
{
    public static class ConsoleExt
    {
        public static void WriteLine(object message)
        {
            Console.WriteLine($"Time: {DateTime.Now.ToShortTimeString()}: {message}");
        }
        public static Task WriteLineAsync(object message)
        {
            return Task.Run(() => WriteLine(message));
        }
    }
}

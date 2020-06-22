using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroductionToCSharp8Book.AsyncStreams
{
    public class Example
    {
        static int SumFromOneToN(int n)
        {
            ConsoleExt.WriteLine("SumFromOneTo() called.");
            int sum = 0;
            for(int i = 0; i <= n; ++i)
            {
                sum += i;
            }
            return sum;
        }
        static IEnumerable<int> SumFromOneToNYield(int n)
        {
            ConsoleExt.WriteLine("SumFromOneTo() called.");
            int sum = 0;
            for (int i = 0; i <= n; ++i)
            {
                sum += i;
                yield return sum;
            }
        }
        static async Task<int> SumFromOneToNAsync(int n)
        {
            return await Task.Run(() => 
            {
                int sum = 0;
                for(int i = 0; i <= n; ++i)
                {
                    sum = sum + i;
                }
                return sum;
            });
        }
        static async Task ConsumeFromOneToNAsyncStream(IAsyncEnumerable<int> sequence)
        {
            await foreach(var item in sequence)
            {
                ConsoleExt.WriteLine($"Consuming {item}");
                Task.Delay(TimeSpan.FromSeconds(0.8)).Wait();
            }
        }
        static async IAsyncEnumerable<int> ProduceAsyncSequence(int n,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            int sum = 0;
            for(int i = 0; i <= n; ++i)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    ConsoleExt.WriteLine("Operation cancelled.");
                    break;
                }

                sum += i;
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                yield return sum;
            }
        }
        public static void Run()
        {

            //var sumStrategy = new Func<int,int>((i) => SumFromOneToN(i));
            //var sumStrategy = new Func<int,int>((i) => 
            //{
            //    int total = 0;
            //    foreach(var sum in SumFromOneToNYield(i))
            //    {
            //        ConsoleExt.WriteLine(sum);
            //        total = sum;
            //    }
            //    return total;
            //});
            //var sumStrategy = new Func<int, Task<int>> (async (i) => await SumFromOneToNAsync(i));


            const int iterations = 5;
            var cts = new CancellationTokenSource();
            cts.CancelAfter(3000);
            var pulledSequence = ProduceAsyncSequence(iterations, cts.Token);

            var beginConsumingData = Task.Run(() => ConsumeFromOneToNAsyncStream(pulledSequence));
            beginConsumingData.Wait();
            ConsoleExt.WriteLine("Consumed all data.");
        }
    }
}

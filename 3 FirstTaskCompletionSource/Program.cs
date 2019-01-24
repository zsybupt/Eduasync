using System;
using System.Threading.Tasks;

namespace Eduasync
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<int> task = Return10Async();
            Console.WriteLine("Main got result: {0}", task.Result);
            Console.ReadKey();
        }

        // Warning CS1998 is about a method with no awaits in... exactly what we're trying to
        // achieve!
#pragma warning disable 1998
        private static async Task<int> Return10Async()
        {
            return 10;
        }
#pragma warning restore 1998
    }
}

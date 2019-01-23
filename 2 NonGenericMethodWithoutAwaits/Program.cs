using System.Threading.Tasks;

namespace Eduasync
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoNothingAsync();
        }

        // Warning CS1998 is about a method with no awaits in... exactly what we're trying to
        // achieve!
#pragma warning disable 1998
        private static async Task DoNothingAsync()
        {
        }
#pragma warning restore 1998
    }
}

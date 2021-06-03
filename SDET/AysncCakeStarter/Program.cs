using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            HaveAParty();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static void HaveAParty()
        {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            var partyTask = PlayPartyGamesAsync();
            var conversationTask = ConversationAsync();
            OpenPresents();
            partyTask.Wait();
            conversationTask.Wait();
            var cake = cakeTask.Result;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        private static async Task<Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static async Task PlayPartyGamesAsync()
        {
            Console.WriteLine("Some people started playing games");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Finishing Games");
        }

        private static async Task ConversationAsync()
        {
            Console.WriteLine("Some people started talking about life");
            await Task.Delay(TimeSpan.FromSeconds(4));
            Console.WriteLine("Finishing talking about life");
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }
}

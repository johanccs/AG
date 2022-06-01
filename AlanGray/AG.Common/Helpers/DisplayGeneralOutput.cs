using System;
using System.Threading;

namespace AG.Common.Helpers
{
    public static class DisplayGeneralOutput
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Allan Gray Twitter Feed");            
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
            Thread.Sleep(2000);
        }

        public static void PrintMessageFooter()
        {
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}

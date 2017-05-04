using System;
using System.Diagnostics;
using Bifrost.Configuration;
using Microsoft.Extensions.Logging;

namespace TextAnalytics.dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole();
            
            Configure.DiscoverAndConfigure(loggerFactory);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.WriteLine("Exiting");

            Process.GetCurrentProcess().Kill();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new System.Threading.Mutex(true, "App-Startup"))
            {
                Console.WriteLine("Starting up...");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                mutex.ReleaseMutex();
            }

            RunProgram();
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }
    }
}

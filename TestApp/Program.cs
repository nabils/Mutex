using System;
using System.Diagnostics;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start(args[0]);

            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            using (var mutex = Mutex.OpenExisting("App-Startup"))
            {
                try
                {
                    if (!mutex.WaitOne(TimeSpan.FromSeconds(60), false))
                    {
                        throw new Exception("There was a problem with App initialisation. Waited 1 minute. Exiting.");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                
                Console.WriteLine("App started. Start testing..");

                for (int i = 0; i < 1000000; i++)
                {
                    Console.WriteLine("Testing... " + i);
                }

                Console.ReadLine();
            }
        }
    }
}

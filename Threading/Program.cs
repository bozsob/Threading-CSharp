using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);

            first.Start();
            second.Start();

            first.Join();
            second.Join();

            AppDomain currAD = AppDomain.CurrentDomain;
            Console.WriteLine(currAD.FriendlyName);
            
            Console.WriteLine("Szál-Id: {0}", Thread.CurrentThread.ManagedThreadId);
            
            Console.ReadKey();

        }

        static void Counting()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: {0} and the Thread: {1}", 
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}

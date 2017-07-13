using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "Hy");
            ThreadPool.QueueUserWorkItem(callback, "Ciao");
            ThreadPool.QueueUserWorkItem(callback, "Zin dobre");
            ThreadPool.QueueUserWorkItem(callback, "Grüss Gott");

            Console.ReadKey();

        }

        static void ShowMyText(object state)
        {
            string myText = (string)state;
            Console.WriteLine("Thread: {0} - myText: {1}", Thread.CurrentThread.ManagedThreadId, myText);
        }
    }
}

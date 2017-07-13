using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string MutexName = "RUNMEONCE";

            try
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException) { }

            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
            }
            else
            {
                // Close the mutex and exit the application
                // because we can only have one instance
                oneMutex.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.ReadKey();
        }
    }
}

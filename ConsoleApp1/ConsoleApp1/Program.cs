using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(JobForThread);
            ThreadPool.QueueUserWorkItem(JobForThread2);
            ThreadPool.QueueUserWorkItem(JobForThread3);
            //JobForThread("f");
            //JobForThread2("f");
            //JobForThread3("f");
            Console.WriteLine("I am not wait!! I doing");
            Console.ReadKey();

        }

        private static void JobForThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Цыкл {i}, выополняется внутри потока из пула {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(20);
            }
        }

        private static void JobForThread2(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\tЦыкл {i}, выополняется внутри потока из пула {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(20);
            }
        }


        private static void JobForThread3(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\t\tЦыкл {i}, выополняется внутри потока из пула {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(20);
            }
        }
    }
}

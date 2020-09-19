using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynch_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Id потоку методу main - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("для запуску нажміть будь яку клавішу:");
            Console.ReadKey();

            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Example1));
            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Example2));
            Report();

            Console.ReadKey();
            Report();


        }

        private static void Example1(object state)
        {
            Console.WriteLine($"Метод Example1 почав виконуватися в потоці {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Метод Example1 закінчив виконуватися в потоці {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Example2(object state)
        {
            Console.WriteLine($"Метод Example2 почав виконуватися в потоці {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
            Console.WriteLine($"Метод Example2 закінчив виконуватися в потоці {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Report()
        {
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxPortThreads);
            ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);


            Console.WriteLine($"Робочі потоки {workerThreads} з {maxWorkerThreads}");
            Console.WriteLine($"ІО потоки {portThreads} з {maxPortThreads}");
            Console.WriteLine(new string('-', 80));
        }
    }
}

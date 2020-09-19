using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(WriteChar));

            Console.WriteLine("For start press any key.");
            Console.ReadKey();

            thread.Start('*');


            for (int i = 0; i < 80; i++)
            {
                Console.Write('-');
                Thread.Sleep(70);
            }
        }


        private static void WriteChar(object arg)
        {
            char ch = (char)arg;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(ch);
                Thread.Sleep(70);
            }
        }
    }
}

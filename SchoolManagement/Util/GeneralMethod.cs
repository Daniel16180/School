using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SchoolManagement
{
    public class GeneralMethod
    {
        public void ShowClassTeacher() {
            Console.WriteLine("1.....1ºA");
            Console.WriteLine("2.....1ºB");
            Console.WriteLine("3.....2ºA");
            Console.WriteLine("4.....2ºB");
            Console.WriteLine("5.....3ºA");
            Console.WriteLine("6.....3ºB");
            Console.WriteLine("7.....4ºA");
            Console.WriteLine("8.....4ºB \n");
        }

        public void Wait(int secs)
        {
            switch (secs)
            {
                case 1:
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                case 2:
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                default:
                    Thread.Sleep(500);
                    Console.Clear();
                    break;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;

namespace SchoolManagement
{
    public class GeneralMethod
    {
        public void ShowClassGroupTable() {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            foreach (var classGroup in classGroupRepository.GetClassgroups())
            {
                Console.WriteLine("Id: " + classGroup.Id + " Year: " + classGroup.Year + "Letter: " + classGroup.Letter);
            }
            Console.WriteLine(" ");
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

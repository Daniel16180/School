using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;

namespace SchoolManagement
{
    public class WhoIs
    {
        public void Who() {
            int menuExit = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1...Who are my teachers?");
                Console.WriteLine("2...Who are my classmates?");
                Console.WriteLine("3...Back to Main Menu \n");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        MyTeachers();
                        break;
                    case 2:
                        MyClassMates();
                        break;
                    case 3:
                        menuExit = 1;
                        break;
                    default:
                        Console.WriteLine("Option unavailable.");
                        break;
                }
            } while (menuExit == 0);
        }

        private void MyTeachers() {
            Console.WriteLine("Write your student number (id)");
            int sn = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Your teachers are: ");
            TeacherRepository q = new TeacherRepository();
            foreach (var PersonDTO in q.MyTeachers(sn))
            {
                Console.WriteLine(PersonDTO.Name + " " + PersonDTO.Surname);
                Thread.Sleep(500);

            }
            Thread.Sleep(2000);
        }

        private void MyClassMates()
        {
            Console.WriteLine("Select your classgroup: ");
            Console.WriteLine("1.....1ºA");
            Console.WriteLine("2.....1ºB");
            Console.WriteLine("3.....2ºA");
            Console.WriteLine("4.....2ºB");
            Console.WriteLine("5.....3ºA");
            Console.WriteLine("6.....3ºB");
            Console.WriteLine("7.....4ºA");
            Console.WriteLine("8.....4ºB \n");
            int classId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert your own id: ");
            int ownId = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Your classmates are: ");

            PupilRepository q = new PupilRepository();
            foreach (var Person2DTO in q.MyMates(classId))
            {
                if (Person2DTO.Id != ownId)
                {
                    Console.WriteLine(Person2DTO.Name + " " + Person2DTO.Surname);
                    Thread.Sleep(500);
                }

            }
            Thread.Sleep(2000);
        }
    }
}

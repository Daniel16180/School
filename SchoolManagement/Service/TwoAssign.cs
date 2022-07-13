using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;

namespace SchoolManagement
{
    public class TwoAssign
    {
        public void AssignTeacher() {
            int exitMenu = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Write the teacher´s name or type 1 to go back to the Main Menu.");
                string na = Console.ReadLine();
                Console.Clear();
                if (na == "1")
                {
                    exitMenu = 1;
                }
                else
                {
                    Console.WriteLine("Enter the surname");
                    string sur = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Select the classgroup to assign");
                    Console.WriteLine("1.....1ºA");
                    Console.WriteLine("2.....1ºB");
                    Console.WriteLine("3.....2ºA");
                    Console.WriteLine("4.....2ºB");
                    Console.WriteLine("5.....3ºA");
                    Console.WriteLine("6.....3ºB");
                    Console.WriteLine("7.....4ºA");
                    Console.WriteLine("8.....4ºB");
                    int cg = Convert.ToInt32(Console.ReadLine());


                    Queries q = new Queries();
                    foreach (var teacher in q.GetTeachers())
                    {
                        if (teacher.Name == na && teacher.Surname == sur)
                        {
                            int idTeacher = teacher.Id;
                            q.SetAssignment(cg, idTeacher);
                            Console.WriteLine("Done!");
                            Thread.Sleep(500);
                            Console.Clear();
                        }

                    }
                }
            } while (exitMenu == 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;
using SchoolManagementEntity;
using System.Linq;

namespace SchoolManagement.Service
{
    public class TeacherService
    {
        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Type the name");
            string name = Console.ReadLine();

            Console.WriteLine("Type the surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Type the salary");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Type the experience");
            int experience = Convert.ToInt32(Console.ReadLine());

            Teacher teacher = new Teacher(1, name, surname, salary, experience, false);
            Console.WriteLine("Printing " + teacher.Name);
            TeacherRepository query1 = new TeacherRepository();
            query1.SetTeacher(teacher);
            Console.WriteLine(teacher.Name + " was succesfully inserted.");
            Thread.Sleep(1000);
        }

        public void ReadAll()
        {
            int exit = 0;
            string continuation = "c";
            while (exit == 0)
            {
                Console.Clear();
                TeacherRepository searchTeachers = new TeacherRepository();
                foreach (var teacher in searchTeachers.GetTeachers())
                {
                    Console.WriteLine("Id: " + teacher.Id + " Name: " + teacher.Name + " Surname: " + teacher.Surname);
                    Console.WriteLine("Salary: " + teacher.Salary + " Experience: " + teacher.Experience + "\n");

                }
                Console.WriteLine("Write \"c\" to continue.");
                continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            }
        }
        public void Update()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.Clear();
                ReadAll();
                Console.WriteLine("Select the id of the teacher whose info you want to update: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert the new salary: ");
                float salary = float.Parse(Console.ReadLine());
                Console.WriteLine("Insert the new experience: ");
                int experience = Convert.ToInt32(Console.ReadLine());


                TeacherRepository updateTeacher = new TeacherRepository();
                updateTeacher.UpdateTeacher(teacherId, salary, experience);
                Console.WriteLine("Updated!");


                Console.WriteLine("Press any key to continue.");
                string continuation = Console.ReadLine();
                exit = 1;
            }
        }
        public void Delete()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.Clear();
                ReadAll();
                Console.WriteLine("Select the id of the teacher you want to remove from the database: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());
                TeacherRepository forgetTeacher = new TeacherRepository();
                forgetTeacher.DeleteTeacher(teacherId);

                Console.Clear();
                Console.WriteLine("Success!");

                Console.WriteLine("Press any key to continue.");
                string continuation = Console.ReadLine();
                exit = 1;
            }
        }

        public void ViewDirector()
        {
            Console.Clear();
            TeacherRepository teacherRepository = new TeacherRepository();
            foreach (var teacher in teacherRepository.GetDirector())
            {
                Console.WriteLine("Name: " + teacher.Name + " Surname: " + teacher.Surname);
                GeneralMethod generalMethod = new GeneralMethod();
                generalMethod.Wait(2);
            }
        }

        public void ElectDirector()
        {
            GeneralMethod generalMethod = new GeneralMethod();
            Console.Clear();
            var votes = new List<int>();
            TeacherRepository query = new TeacherRepository();
            foreach (var teacher in query.GetTeachers())
            {
                Console.WriteLine(teacher.Name);
                Random randomVotes = new Random();
                int randomNumber = randomVotes.Next(50, 500);
                Console.WriteLine(randomNumber + "votes.");
                votes.Add(randomNumber);
                Thread.Sleep(500);

            }
            Thread.Sleep(5000);
            Console.Clear();
            int[] positions = votes.ToArray();
            Console.WriteLine("The winner has " + positions.Max() + "votes!");
            int winnerPosition = Convert.ToInt32(Array.IndexOf(positions, positions.Max()));
            int realWinnerPosition = winnerPosition++;
            Console.WriteLine("The candidate number " + winnerPosition + " won.");
            generalMethod.Wait(2);

            query.unsetDirector();
            query.setDirector(winnerPosition);
        }

        public void AssignToClass()
        {
            int exitMenu = 0;
            Console.Clear();
            while (exitMenu == 0)
            {
                Console.WriteLine("Write the teacher´s name or type 1 to go back to the Main Menu.");
                string name = Console.ReadLine();
                Console.Clear();
                if (name == "1")
                {
                    exitMenu = 1;
                }
                else
                {
                    Console.WriteLine("Enter the surname");
                    string surname = Console.ReadLine();
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
                    int classGroup = Convert.ToInt32(Console.ReadLine());


                    TeacherRepository query = new TeacherRepository();
                    foreach (var teacher in query.GetTeachers())
                    {
                        if (teacher.Name == name && teacher.Surname == surname)
                        {
                            int idTeacher = teacher.Id;
                            query.SetAssignment(classGroup, idTeacher);
                            Console.WriteLine("Done!");
                            Thread.Sleep(500);
                            Console.Clear();
                        }

                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;

namespace SchoolManagement
{
    public class SevenMPeople
    {
        public void MPeople() {
            int menuSelection = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.........Consult teachers");
                Console.WriteLine("2...........Consult pupils");
                Console.WriteLine("3...Update teacher profile");
                Console.WriteLine("4.....Update pupil profile");
                Console.WriteLine("5...Delete teacher profile");
                Console.WriteLine("6.....Delete pupil profile");
                Console.WriteLine("7..........Search director");
                Console.WriteLine("8.....................Back \n");

                menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        ConTeacher();
                        break;
                    case 2:
                        ConPupil();
                        break;
                    case 3:
                        ChangeTeacher();
                        break;
                    case 4:
                        ChangePupil();
                        break;
                    case 5:
                        ForgetTeacher();
                        break;
                    case 6:
                        ForgetPupil();
                        break;
                    case 7:
                        SearchDirector();
                        break;
                    case 8:
                        menuSelection = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (menuSelection == 0);
        }

        private void ConTeacher() {
            int exit = 0;
            string continuation = "c";
            do
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
            } while (exit == 0);   
        }

        private void ConPupil()
        {
            int exit = 0;
            do
            {
                Console.Clear();
                PupilRepository searchPupilss = new PupilRepository();
                foreach (var pupil in searchPupilss.GetPupils())
                {
                    Console.WriteLine("Id: " + pupil.Id + " Name: " + pupil.Name + " Surname: " + pupil.Surname);
                    Console.WriteLine("Age: " + pupil.Age + " Classgroup id: " + pupil.IdClassgroup + "\n");

                }
                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            } while (exit == 0);
        }

        private void ChangeTeacher()
        {
            int exit = 0;
            do
            {
                Console.Clear();
                ConTeacher();
                Console.WriteLine("Select the id of the teacher whose info you want to update: ");
                int idTeacher = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert the new salary: ");
                float salary= float.Parse(Console.ReadLine());
                Console.WriteLine("Insert the new experience: ");
                int exp = Convert.ToInt32(Console.ReadLine());


                TeacherRepository updateTeacher = new TeacherRepository();
                updateTeacher.UpdateTeacher(idTeacher, salary, exp);
                Console.WriteLine("Updated!");
                

                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            } while (exit == 0);
        }

        private void ChangePupil()
        {
            int exit = 0;
            do
            {
                Console.Clear();
                ConPupil();
                Console.WriteLine("Select the id of the pupil whose info you want to update: ");
                int idPupil = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert the new age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                ClassgroupRepository updatePupil = new ClassgroupRepository();
                PupilRepository pr = new PupilRepository();

                foreach (var classgroup in updatePupil.GetClassgroups())
                {
                    Console.WriteLine("Id: " + classgroup.Id + " Year: " + classgroup.Year + " Letter: " + classgroup.Letter);
                }
                Console.WriteLine("Insert the new classgroup id: ");
                int classId = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                pr.UpdatePupil(idPupil, age, classId);
                Console.WriteLine("Profile updated!");


                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            } while (exit == 0);
        }

        private void ForgetTeacher()
        {
            int exit = 0;
            do
            {
                Console.Clear();
                ConTeacher();
                Console.WriteLine("Select the id of the teacher you want to remove from the database: ");
                int idTeacher = Convert.ToInt32(Console.ReadLine());
                TeacherRepository forgetTeacher = new TeacherRepository();
                forgetTeacher.DeleteTeacher(idTeacher);

                Console.Clear();
                Console.WriteLine("Success!");

                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            } while (exit == 0);
        }

        private void ForgetPupil()
        {
            int exit = 0;
            do
            {
                Console.Clear();
                ConPupil();
                Console.WriteLine("Select the id of the pupil you want to remove from the database: ");
                int idPupil= Convert.ToInt32(Console.ReadLine());
                PupilRepository forgetPupil = new PupilRepository();
                forgetPupil.DeletePupil(idPupil);

                Console.Clear();
                Console.WriteLine("Success!");

                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    exit = 1;
                }
            } while (exit == 0);
        }

        public void SearchDirector() {
            Console.Clear();
            TeacherRepository tr = new TeacherRepository();
            foreach (var teacher in tr.GetDirector())
            {
                Console.WriteLine("Name: " + teacher.Name + " Surname: " + teacher.Surname);
                GeneralMethod gm = new GeneralMethod();
                gm.Wait(2);
            }
        }
    }
}

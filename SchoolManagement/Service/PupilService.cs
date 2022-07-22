using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;
using SchoolManagementEntity;

namespace SchoolManagement.Service
{
    public class PupilService
    {
        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Type the name");
            string name = Console.ReadLine();

            Console.WriteLine("Type the surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Type the age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the classgroup code");
            int classGroupCode = Convert.ToInt32(Console.ReadLine());

            Pupil pupil = new Pupil(1, name, surname, age, classGroupCode);
            //Console.WriteLine("Printing " + p.Name);
            PupilRepository query1 = new PupilRepository();
            query1.SetPupil(pupil);
            Console.WriteLine(pupil.Name + " was succesfully inserted.");
            Thread.Sleep(500);
        }
        public void ReadAll()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.Clear();
                PupilRepository searchPupilss = new PupilRepository();
                foreach (var pupil in searchPupilss.GetPupils())
                {
                    Console.WriteLine("Id: " + pupil.Id + " Name: " + pupil.Name + " Surname: " + pupil.Surname);
                    Console.WriteLine("Age: " + pupil.Age + " Classgroup id: " + pupil.ClassGroupId + "\n");

                }
                Console.WriteLine("Write \"c\" to continue.");
                string continuation = Console.ReadLine();
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
                Console.WriteLine("Select the id of the pupil whose info you want to update: ");
                int idPupil = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert the new age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                ClassGroupRepository updatePupil = new ClassGroupRepository();
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
            }
        }
        public void Delete()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.Clear();
                ReadAll();
                Console.WriteLine("Select the id of the pupil you want to remove from the database: ");
                int idPupil = Convert.ToInt32(Console.ReadLine());
                PupilRepository forgetPupil = new PupilRepository();
                forgetPupil.DeletePupil(idPupil);

                Console.Clear();
                Console.WriteLine("Success!");

                Console.WriteLine("Press any key to continue.");
                string continuation = Console.ReadLine();
                exit = 1;
            }
        }

        public void FindMates()
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

            PupilRepository query = new PupilRepository();
            foreach (var Person2DTO in query.MyMates(classId))
            {
                if (Person2DTO.Id != ownId)
                {
                    Console.WriteLine(Person2DTO.Name + " " + Person2DTO.Surname);
                    Thread.Sleep(500);
                }

            }
            Thread.Sleep(2000);
        }

        public void FindMyTeachers()
        {
            Console.WriteLine("Write your student number (id)");
            int studentNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Your teachers are: ");
            TeacherRepository query = new TeacherRepository();
            foreach (var PersonDTO in query.MyTeachers(studentNumber))
            {
                Console.WriteLine(PersonDTO.Name + " " + PersonDTO.Surname);
                Thread.Sleep(500);

            }
            Thread.Sleep(2000);
        }
    }
}

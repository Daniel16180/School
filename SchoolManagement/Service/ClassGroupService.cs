using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;
using SchoolManagementEntity;

namespace SchoolManagement.Service
{
    public class ClassGroupService
    {
        public void Create()
        {
            Consult();
            Console.WriteLine("Write a year for the new classgroup:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write a letter that is currently not used:");
            string letter = Console.ReadLine();
            ClassGroupRepository query = new ClassGroupRepository();
            query.SetClassgroup(year, letter);
            Console.Clear();
            Console.WriteLine("The new classgroup has been created.");
            Thread.Sleep(1000);
        }

        public void Consult()
        {
            int consult = 0;
            while (consult == 0)
            {
                Console.Clear();
                Console.WriteLine("Retrieving all currentl existing classgroups");
                Thread.Sleep(1000);
                Console.Clear();
                ClassGroupRepository query = new ClassGroupRepository();
                foreach (var classgroup in query.GetClassgroups())
                {
                    Console.WriteLine("Id: " + classgroup.Id + " Year: " + classgroup.Year + " Letter: " + classgroup.Letter);
                }
                Console.WriteLine("\n Press any key to continue");
                string continuation = Console.ReadLine();
                consult = 1;
            }
        }
        public void Change()
        {
            Console.Clear();
            Consult();
            Console.WriteLine("Select the id of the classgroup you want to edit.");
            int identification = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the new year.");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the new letter.");
            string letter = Console.ReadLine();
            ClassGroup classGroup = new ClassGroup(identification, year, letter);
            ClassGroupRepository query = new ClassGroupRepository();
            query.UpdateClassgroup(classGroup);
            Console.Clear();
            Console.WriteLine("Classgroup has been updated.");
            Thread.Sleep(1000);
        }
        public void Delete()
        {
            Console.Clear();
            Consult();
            Console.WriteLine("Select the id of the classgroup you want to delete.");
            int identification = Convert.ToInt32(Console.ReadLine());
            ClassGroupRepository query = new ClassGroupRepository();
            query.DeleteClassgroup(identification);
            Console.WriteLine("Class with id: " + identification + " removed.");
            Thread.Sleep(1000);
        }
        public void Merge()
        {
            Console.Clear();
            GeneralMethod generalMethod = new GeneralMethod();
            generalMethod.ShowClassTeacher();
            generalMethod.Wait(2);

            Console.WriteLine("Select the group you want to merge into a second one");
            int firstGroup = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select the second group");
            int secondGroup = Convert.ToInt32(Console.ReadLine());

            ClassGroupRepository query1 = new ClassGroupRepository();
            query1.Merge(firstGroup, secondGroup);
            TeacherRepository query2 = new TeacherRepository();


            Console.WriteLine("Both groups where succesfully merged into one.");
            generalMethod.Wait(1);

            Console.WriteLine($"The teachers in the classgroup with id {firstGroup} are bored. Those teachers are: ");
            foreach (var Person2DTO in query2.findUnassignTeachers(firstGroup))
            {
                Console.WriteLine("Id: " + Person2DTO.Id + " Name: " + Person2DTO.Name + " Surname: " + Person2DTO.Surname);
            }
            Thread.Sleep(1000);
            Console.WriteLine("Please, reassign them to new classgroups. \n");
            foreach (var Person2DTO in query2.findUnassignTeachers(firstGroup))
            {
                generalMethod.ShowClassTeacher();
                Console.WriteLine($"{Person2DTO.Name} {Person2DTO.Surname} goes to classgroup: ");
                Console.WriteLine("(Insert classgroup id)");
                int newCgId = Convert.ToInt32(Console.ReadLine());
                if (newCgId > 0 && newCgId < 8 && newCgId != firstGroup)
                {
                    query2.SetAssignment(newCgId, Person2DTO.Id);
                    Console.WriteLine($"{Person2DTO.Name} was assigned.");
                }
                else
                {
                    Console.WriteLine("Invalid group.");
                }
                generalMethod.Wait(1);
            }

            query2.unassignTeachers(firstGroup); //since it is prevented to use this var in the new assignment, it is safe to delete those rows.
        }
    }
}

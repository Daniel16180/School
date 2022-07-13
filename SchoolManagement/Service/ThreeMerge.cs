using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;

namespace SchoolManagement
{
    public class ThreeMerge
    {
        public void Merge() {
            Console.Clear();
            GeneralMethod gm = new GeneralMethod();
            gm.ShowClassTeacher();
            gm.Wait(2);

            Console.WriteLine("Select the group you want to merge into a second one");
            int fg = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select the second group");
            int sg = Convert.ToInt32(Console.ReadLine());

            Queries q = new Queries();
            q.Merge(fg, sg);
            
            Console.WriteLine("Both groups where succesfully merged into one.");
            gm.Wait(1);

            Console.WriteLine($"The teachers in the classgroup with id {fg} are bored. Those teachers are: ");
            foreach (var Person2DTO in q.findUnassignTeachers(fg))
            {
                Console.WriteLine("Id: " + Person2DTO.Id + " Name: " + Person2DTO.Name + " Surname: " + Person2DTO.Surname);
            }
            Thread.Sleep(1000);
            Console.WriteLine("Please, reassign them to new classgroups. \n");
            foreach (var Person2DTO in q.findUnassignTeachers(fg))
            {
                gm.ShowClassTeacher();
                Console.WriteLine($"{Person2DTO.Name} {Person2DTO.Surname} goes to classgroup: ");
                Console.WriteLine("(Insert classgroup id)");
                int newCgId = Convert.ToInt32(Console.ReadLine());
                if (newCgId > 0 && newCgId < 8 && newCgId != fg)
                {
                    q.SetAssignment(newCgId, Person2DTO.Id);
                    Console.WriteLine($"{Person2DTO.Name} was assigned.");
                }
                else {
                    Console.WriteLine("Invalid group.");
                }
                gm.Wait(1);
            }

            q.unassignTeachers(fg); //since it is prevented to use this var in the new assignment, it is safe to delete those rows.

        }
    }
}

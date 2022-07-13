using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;
using SchoolManagementEntity;

namespace SchoolManagement
{
    public class SixMClassgroup
    {
        int menuSelection = 0;
        public void ManageClassgroups()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1..............Create classgroup");
                Console.WriteLine("2...Consult existing classgroups");
                Console.WriteLine("3...Change classgroup properties");
                Console.WriteLine("4..............Delete classgroup");
                Console.WriteLine("5...........................Back \n");

                menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Consult();
                        break;
                    case 3:
                        Change();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        menuSelection = 1;
                        break;
                    default:
                        break;
                }
            } while (menuSelection == 0);
        }

        private void Create() {
            Consult();
            Console.WriteLine("Write a year for the new classgroup:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write a letter that is currently not used:");
            string letter = Console.ReadLine();
            ClassgroupRepository q = new ClassgroupRepository();
            q.SetClassgroup(year, letter);
            Console.Clear();
            Console.WriteLine("The new classgroup has been created.");
            Thread.Sleep(1000);


        }

        private void Consult() {
            int consult = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Retrieving all currentl existing classgroups");
                Thread.Sleep(1000);
                Console.Clear();
                ClassgroupRepository q = new ClassgroupRepository();
                foreach (var classgroup in q.GetClassgroups())
                {
                    Console.WriteLine("Id: " + classgroup.Id + " Year: " + classgroup.Year + " Letter: " + classgroup.Letter);
                }
                Console.WriteLine("\n Write \"c\" to continue");
                string continuation = Console.ReadLine();
                if (continuation == "c")
                {
                    consult = 1;
                }
            } while (consult == 0);
        }

        private void Change() {
            Console.Clear();
            Consult();
            Console.WriteLine("Select the id of the classgroup you want to edit.");
            int identification = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the new year.");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the new letter.");
            string letter = Console.ReadLine();
            Classgroup c = new Classgroup(identification, year, letter);
            ClassgroupRepository q = new ClassgroupRepository();
            q.UpdateClassgroup(c);
            Console.Clear();
            Console.WriteLine("Classgroup has been updated.");
            Thread.Sleep(1000);

        }

        private void Delete() {
            Console.Clear();
            Consult();
            Console.WriteLine("Select the id of the classgroup you want to delete.");
            int identification = Convert.ToInt32(Console.ReadLine());
            ClassgroupRepository q = new ClassgroupRepository();
            q.DeleteClassgroup(identification);
            Console.WriteLine("Class with id: " + identification + " removed.");
            Thread.Sleep(1000);
        }
    }
}

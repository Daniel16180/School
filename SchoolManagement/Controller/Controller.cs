using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementEntity;

namespace SchoolManagement
{
    class Controller
    {
        public void Start() {
            int menuExit = 0;
            int menuSelection = 0;
            Classgroup cg1 = new Classgroup(1, 3, "a");

            //START
            Console.WriteLine("Welcome to School Management!");
            Thread.Sleep(1000);
            Console.Clear();

            //MAIN MENU
            do
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("");
                Console.WriteLine("1..............Insert new data");
                Console.WriteLine("2...............Assign teacher");
                Console.WriteLine("3............Merge classgroups");
                Console.WriteLine("4...............Elect director");
                Console.WriteLine("5...................Who is who");
                Console.WriteLine("6...........Manage classgroups");
                Console.WriteLine("7...Manage teachers and pupils");
                Console.WriteLine("8.........................Exit");
                Console.WriteLine("");

                menuSelection = Convert.ToInt32(Console.ReadLine());

                if (menuSelection < 1 || menuSelection > 8)
                {
                    Console.Clear();
                    Console.WriteLine("Option not found");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    switch (menuSelection)
                    {
                        case 1:
                            OneInsertData insertion = new OneInsertData();
                            insertion.MenuInsert();
                            break;
                        case 2:
                            TwoAssign assign = new TwoAssign();
                            assign.AssignTeacher();
                            break;
                        case 3:
                            ThreeMerge mer = new ThreeMerge();
                            mer.Merge();
                            break;
                        case 4:
                            FourElection elect = new FourElection();
                            elect.Elections();
                            break;
                        case 5:
                            WhoIs who = new WhoIs();
                            who.Who();
                            break;
                        case 6:
                            SixMClassgroup sixMClassgroup = new SixMClassgroup();
                            sixMClassgroup.ManageClassgroups();
                            break;
                        case 7:
                            SevenMPeople seven = new SevenMPeople();
                            seven.MPeople();
                            break;
                        case 8:
                            menuExit = 1;
                            break;
                        default:
                            break;
                    }
                }

            } while (menuExit == 0);
   
        }
    }
}

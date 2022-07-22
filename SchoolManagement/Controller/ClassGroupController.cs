using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Service;

namespace SchoolManagement
{
    public class ClassGroupController
    {
        public void ClassGroupMenu()
        {
            int exitMenu = 0;
            ClassGroupService classGroupService = new ClassGroupService();

            while (exitMenu == 0)
            {
                Console.Clear();
                Console.WriteLine("1..............Create classgroup");
                Console.WriteLine("2...Consult existing classgroups");
                Console.WriteLine("3...Change classgroup properties");
                Console.WriteLine("4..............Delete classgroup");
                Console.WriteLine("5...............Merge classgroup \n");
                Console.WriteLine("6...........................Back \n");

                int menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        classGroupService.Create();
                        break;
                    case 2:
                        classGroupService.Consult();
                        break;
                    case 3:
                        classGroupService.Change();
                        break;
                    case 4:
                        classGroupService.Delete();
                        break;
                    case 5:
                        classGroupService.Merge();
                        break;
                    case 6:
                        exitMenu = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

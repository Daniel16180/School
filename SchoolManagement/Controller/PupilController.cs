using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Service;

namespace SchoolManagement
{
    public class PupilController
    {
        public void PupilMenu()
        {
            int exitMenu = 0;
            PupilService pupilService = new PupilService();

            while (exitMenu == 0)
            {
                Console.Clear();
                Console.WriteLine("1...................Insert pupil");
                Console.WriteLine("2.............Consult all pupils");
                Console.WriteLine("3...................Edit profile");
                Console.WriteLine("4.................Delete profile");
                Console.WriteLine("5..............Who are my mates?");
                Console.WriteLine("6...........Who are my teachers? \n");
                Console.WriteLine("7...........................Back \n");

                int menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        pupilService.Create();
                        break;
                    case 2:
                        pupilService.ReadAll();
                        break;
                    case 3:
                        pupilService.Update();
                        break;
                    case 4:
                        pupilService.Delete();
                        break;
                    case 5:
                        pupilService.FindMates();
                        break;
                    case 6:
                        pupilService.FindMyTeachers();
                        break;
                    case 7:
                        exitMenu = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

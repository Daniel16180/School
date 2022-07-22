using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Service;

namespace SchoolManagement
{
    public class TeacherController
    {
        public void TeacherMenu()
        {
            int exitMenu = 0;
            TeacherService teacherService = new TeacherService();

            while (exitMenu == 0)
            {
                Console.Clear();
                Console.WriteLine("1..................Insert teacher");
                Console.WriteLine("2............Consult all teachers");
                Console.WriteLine("3....................Edit profile");
                Console.WriteLine("4..................Delete profile");
                Console.WriteLine("5...Which teacher is the director");
                Console.WriteLine("6..............Elect new director");
                Console.WriteLine("7.........Assign teacher to class \n");
                Console.WriteLine("8...........................Back \n");

                int menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        teacherService.Create();
                        break;
                    case 2:
                        teacherService.ReadAll();
                        break;
                    case 3:
                        teacherService.Update();
                        break;
                    case 4:
                        teacherService.Delete();
                        break;
                    case 5:
                        teacherService.ViewDirector();
                        break;
                    case 6:
                        teacherService.ElectDirector();
                        break;
                    case 7:
                        teacherService.AssignToClass();
                        break;
                    case 8:
                        exitMenu = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

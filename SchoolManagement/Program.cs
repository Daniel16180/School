using System;

namespace SchoolManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            int mainMenuExit = 0;
            GeneralMethod generalMethod = new GeneralMethod();

            while (mainMenuExit == 0)
            {
                Console.Clear();
                Console.WriteLine("SCHOOL MANAGEMENT \n");
                Console.WriteLine("Manage... \n");
                Console.WriteLine("1......ClassGroup");
                Console.WriteLine("2...........Pupil");
                Console.WriteLine("3.........Teacher \n");
                Console.WriteLine("Or... \n");
                Console.WriteLine("4...Exit programm \n");
                int mainMenuElection = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuElection)
                {
                    case 1:
                        ClassGroupController classGroupController = new ClassGroupController();
                        classGroupController.ClassGroupMenu();
                        break;
                    case 2:
                        PupilController pupilController = new PupilController();
                        pupilController.PupilMenu();
                        break;
                    case 3:
                        TeacherController teacherController = new TeacherController();
                        teacherController.TeacherMenu();
                        break;
                    case 4:
                        mainMenuExit = 1;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Option not found.");
                        generalMethod.Wait(1);
                        break;
                }
            }

        }
    }
}

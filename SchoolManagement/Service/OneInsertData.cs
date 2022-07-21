using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SchoolManagementRepo;
using SchoolManagementEntity;

namespace SchoolManagement
{
    public class OneInsertData
    {
        //SELECTION
        public void MenuInsert()
        {
            int menuInsert = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1........Insert teacher");
                Console.WriteLine("2..........Insert pupil");
                Console.WriteLine("3...Back to main screen");
                Console.WriteLine("");

                menuInsert = Convert.ToInt32(Console.ReadLine());

                if (menuInsert < 1 || menuInsert > 3)
                {
                    Console.Clear();
                    Console.WriteLine("Option not found");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else
                {
                    switch (menuInsert)
                    {
                        case 1:
                            InsertTeacher();
                            break;
                        case 2:
                            InsertPupil();
                            break;
                        case 3:
                            menuInsert = 1;
                            break;
                        default:
                            break;
                    }

                }
            } while (menuInsert == 0);
            //INSERT TEACHER
            //INSERT PUPIL
        }

        private void InsertTeacher() {
            Console.Clear();
            Console.WriteLine("Type the name");
            string na = Console.ReadLine();

            Console.WriteLine("Type the surname");
            string sna = Console.ReadLine();

            Console.WriteLine("Type the salary");
            decimal sa = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Type the experience");
            int ex = Convert.ToInt32(Console.ReadLine());

            Teacher t = new Teacher(1, na, sna, sa, ex, false);
            Console.WriteLine("Printing " + t.Name);
            TeacherRepository q1 = new TeacherRepository();
            q1.SetTeacher(t);
            Console.WriteLine(t.Name + " was succesfully inserted.");
            Thread.Sleep(1000);
        }

        private void InsertPupil()
        {
            Console.Clear();
            Console.WriteLine("Type the name");
            string na = Console.ReadLine();

            Console.WriteLine("Type the surname");
            string sna = Console.ReadLine();

            Console.WriteLine("Type the age");
            int ag = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the classgroup code");
            int cgc = Convert.ToInt32(Console.ReadLine());

            Pupil p = new Pupil(1, na, sna, ag, cgc);
            //Console.WriteLine("Printing " + p.Name);
            PupilRepository q1 = new PupilRepository();
            q1.SetPupil(p);
            Console.WriteLine(p.Name + " was succesfully inserted.");
            Thread.Sleep(500);
        }
    }
}

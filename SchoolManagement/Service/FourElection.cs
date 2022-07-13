using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.Linq;
using SchoolManagementRepo;


namespace SchoolManagement
{
    public class FourElection
    {
        public void Elections() {
            GeneralMethod gm = new GeneralMethod();
            Console.Clear();
            var votes = new List<int>();
            Queries q = new Queries();
            foreach (var teacher in q.GetTeachers())
            {
                Console.WriteLine(teacher.Name);
                Random rd = new Random();
                int randNum = rd.Next(50, 500);
                Console.WriteLine(randNum + "votes.");
                votes.Add(randNum);
                Thread.Sleep(500);
                
            }
            Thread.Sleep(5000);
            Console.Clear();
            int[] positions = votes.ToArray();
            Console.WriteLine("The winner has " + positions.Max() + "votes!");
            int winPos = Convert.ToInt32(Array.IndexOf(positions, positions.Max()));
            int realWinPos = winPos++;
            Console.WriteLine("The candidate number " +  winPos + " won.");
            gm.Wait(2);

            q.unsetDirector();
            q.setDirector(winPos);

        }
    }
}

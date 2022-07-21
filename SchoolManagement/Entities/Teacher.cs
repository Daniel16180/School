using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Salary { get; set; }
        public int Experience { get; set; }
        public bool Director { get; set; }

        public Teacher(int id, string name, string surname, float salary, int experience, bool director)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Salary = salary;
            Experience = experience;
            Director = director;
        }
    }
}

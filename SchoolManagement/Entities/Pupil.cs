using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    public class Pupil : People
    {
        public int Age { get; set; }
        public int IdClassgroup { get; set; }

        public Pupil(int id, string name, string surname, int age, int idClassgroup)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            IdClassgroup = idClassgroup;
        }
    }
}

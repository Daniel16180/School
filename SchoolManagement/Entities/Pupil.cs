using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    public class Pupil 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int ClassGroupId { get; set; }

        public Pupil(int id, string name, string surname, int age, int classGroupId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            ClassGroupId = classGroupId;
        }
    }
}

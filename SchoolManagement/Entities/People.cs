using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    abstract public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

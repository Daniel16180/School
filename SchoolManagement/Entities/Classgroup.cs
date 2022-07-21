using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    public class ClassGroup //class
    {
        //attibutes have get and set, fields not. The fields are auxiliary variables for tha attibutes/class.
        public int Id { get; set; }
        public int Year { get; set; } //1º, 2º, 3º and 4º.
        public string Letter { get; set; }//a or b

        public ClassGroup(int id, int year, string letter)
        {
            Id = id;
            Year = year;
            Letter = letter;
        }
    }
}

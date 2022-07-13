using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementEntity
{
    public class Classgroup //class
    {
        //atributos los declaro con get y set y los campos sin. Los campos son variables auxiliares para los atributos o clase.
        public int Id { get; set; }
        public int Year { get; set; } //1º, 2º, 3º and 4º.
        public string Letter { get; set; }//a or b

        public Classgroup(int id, int year, string letter)
        {
            Id = id;
            Year = year;
            Letter = letter;
        }
    }
}

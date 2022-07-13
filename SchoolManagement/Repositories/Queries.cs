using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using SchoolManagement;
using SchoolManagementEntity;

namespace SchoolManagementRepo
{
    class Queries
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Teacher> GetTeachers()
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                //al poner el alias relaciona la clase con la tabla, no hacen falta tags
                var teacher = conexion.Query<Teacher>("SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience FROM Teacher");
                return teacher;
            }
        }

        public void SetTeacher(Teacher t)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Teacher (first_name, last_name, salary, experience) VALUES(@Name, @Surname, @Salary, @Experience)";

                int rowsAffected = conexion.Execute(sqlQuery, t);
            }
        }

        public IEnumerable<Pupil> GetPupils()
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                var pupil = conexion.Query<Pupil>("SELECT id as Id, first_name as Name, last_name as Surname, age as Age, id_classgroup as IdClassgroup FROM Pupil");
                return pupil;
            }
        }

        public void SetPupil(Pupil p)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Pupil (first_name, last_name, age, id_classgroup) VALUES(@Name, @Surname, @Age, @IdClassgroup)";

                int rowsAffected = conexion.Execute(sqlQuery, p);
            }
        }

        public void SetAssignment(int idClasgroup, int idTeacher)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Classgroup_Teacher (id_classgroup, id_teacher) VALUES("+ idClasgroup + ", " + idTeacher + ")";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void Merge(int firstGroup, int segondGroup)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "UPDATE Pupil SET id_classgroup = " + segondGroup + " WHERE id_classgroup = " + firstGroup;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void unassignTeachers(int fg) { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "DELETE FROM Classgroup_Teacher WHERE id_classgroup = " + fg;

                int rowsAffected = conexion.Execute(sqlQuery); 
            }
        }


        public void setDirector(int winsPos)
        { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 'YES' WHERE id = " + winsPos;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void unsetDirector()
        { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 'NO'";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2DTO> findUnassignTeachers(int fg)
        { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                var Person2DTOList = conexion.Query < Person2DTO > (@"SELECT dbo.Teacher.id as Id, dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname
                                  FROM dbo.Teacher, dbo.Classgroup_Teacher
                                  WHERE dbo.Classgroup_Teacher.id_teacher = dbo.Teacher.id AND  dbo.Classgroup_Teacher.id_classgroup = " + fg);

                return Person2DTOList.ToList().AsReadOnly();
            }
        }

        public IReadOnlyList<PersonDTO> MyTeachers(int idPupil)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                
                var personDTOList = conexion.Query<PersonDTO>(@"SELECT dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname 
                                                                FROM dbo.Teacher, dbo.Classgroup_Teacher, dbo.Pupil
                                                                WHERE dbo.Teacher.id = dbo.Classgroup_Teacher.id_teacher AND dbo.Classgroup_Teacher.id_classgroup = dbo.Pupil.id_classgroup AND dbo.Pupil.id =" + idPupil);
                return personDTOList.ToList().AsReadOnly();
            }
        }

        public IReadOnlyList<Person2DTO> MyMates(int idClass)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();


                var personDTOList = conexion.Query<Person2DTO>(@"SELECT id as Id, first_name as Name, last_name as Surname FROM dbo.Pupil WHERE id_classgroup = " + idClass);
                return personDTOList.ToList().AsReadOnly();
            }
        }

        public IEnumerable<Classgroup> GetClassgroups()
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                var classgroup = conexion.Query<Classgroup>("SELECT id as Id, year as Year, letter as Letter FROM Classgroup");
                return classgroup;
            }
        }

        public void SetClassgroup(int year, string letter)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Classgroup (year, letter) VALUES(" + year + ", '" + letter + "')";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void UpdateClassgroup(Classgroup c)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"UPDATE Classgroup
                                    SET year= " + c.Year + ", letter= '" + c.Letter + "' " +
                                    "WHERE id= " + c.Id;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void DeleteClassgroup(int identification)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"DELETE FROM Classgroup
                                    WHERE id = " + identification;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void UpdateTeacher(int idTeacher, float salary, int exp)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"UPDATE Teacher
                                    SET salary= " + salary + ", experience = " + exp + " " +
                                    "WHERE id= " + idTeacher;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void UpdatePupil(int idPupil, int age, int classId)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"UPDATE Pupil
                                    SET age= " + age + ", id_classgroup = " + classId + " " +
                                    "WHERE id= " + idPupil;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void DeleteTeacher(int idTeacher)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"DELETE FROM Teacher
                                    WHERE id = " + idTeacher;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void DeletePupil(int idPupil)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = @"DELETE FROM Pupil
                                    WHERE id = " + idPupil;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }
    }


    

    public class PersonDTO {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Person2DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}


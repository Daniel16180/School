using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using SchoolManagement;
using SchoolManagementEntity;
using SchoolManagement.Entities.DTO;

namespace SchoolManagementRepo
{
    class TeacherRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Teacher> GetTeachers()
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                //al poner el alias relaciona la clase con la tabla, no hacen falta tags
                var teacher = conexion.Query<Teacher>("SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director FROM Teacher");
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

        public void SetAssignment(int idClasgroup, int idTeacher)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Classgroup_Teacher (id_classgroup, id_teacher) VALUES(" + idClasgroup + ", " + idTeacher + ")";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void unassignTeachers(int fg)
        { //fg=first group, the one without pupils
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

                string sqlQuery = "UPDATE dbo.Teacher SET director = 1 WHERE id = " + winsPos;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public void unsetDirector()
        { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 0";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2DTO> findUnassignTeachers(int fg)
        { //fg=first group, the one without pupils
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                var Person2DTOList = conexion.Query<Person2DTO>(@"SELECT dbo.Teacher.id as Id, dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname
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

        public IEnumerable<Teacher> GetDirector()
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                //al poner el alias relaciona la clase con la tabla, no hacen falta tags
                var teacher = conexion.Query<Teacher>(@"SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director
                                                      FROM Teacher
                                                      WHERE director= 1");
                return teacher;
            }
        }
    }
}

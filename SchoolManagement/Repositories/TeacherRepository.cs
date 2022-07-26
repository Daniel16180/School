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
    class TeacherRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Teacher> GetTeachers()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                //using alias relate them to the table, no tags are needed.
                var teacher = connection.Query<Teacher>("SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director FROM Teacher");
                return teacher;
            }
        }

        public void SetTeacher(Teacher teacher)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Teacher (first_name, last_name, salary, experience) VALUES(@Name, @Surname, @Salary, @Experience)";

                int rowsAffected = connection.Execute(sqlQuery, teacher);
            }
        }

        public void UpdateTeacher(int teacherId, float salary, int experience)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Teacher
                                    SET salary= " + salary + ", experience = " + experience + " " +
                                    "WHERE id= " + teacherId;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeleteTeacher(int TeacherId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Teacher
                                    WHERE id = " + TeacherId;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void SetAssignment(int idClasgroup, int teacherId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Classgroup_Teacher (id_classgroup, id_teacher) VALUES(" + idClasgroup + ", " + teacherId + ")";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void unassignTeachers(int firstGroup)
        { //fg=first group, the one without pupils
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "DELETE FROM Classgroup_Teacher WHERE id_classgroup = " + firstGroup;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void setDirector(int winnerPosition)
        { //fg=first group, the one without pupils
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 1 WHERE id = " + winnerPosition;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void unsetDirector()
        { //fg=first group, the one without pupils
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 0";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2DTO> findUnassignTeachers(int firstGroup)
        { //fg=first group, the one without pupils
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var Person2DTOList = connection.Query<Person2DTO>(@"SELECT dbo.Teacher.id as Id, dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname
                                  FROM dbo.Teacher, dbo.Classgroup_Teacher
                                  WHERE dbo.Classgroup_Teacher.id_teacher = dbo.Teacher.id AND  dbo.Classgroup_Teacher.id_classgroup = " + firstGroup);

                return Person2DTOList.ToList().AsReadOnly();
            }
        }

        public IReadOnlyList<PersonDTO> MyTeachers(int pupilId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();


                var personDTOList = connection.Query<PersonDTO>(@"SELECT dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname 
                                                                FROM dbo.Teacher, dbo.Classgroup_Teacher, dbo.Pupil
                                                                WHERE dbo.Teacher.id = dbo.Classgroup_Teacher.id_teacher AND dbo.Classgroup_Teacher.id_classgroup = dbo.Pupil.id_classgroup AND dbo.Pupil.id =" + pupilId);
                return personDTOList.ToList().AsReadOnly();
            }
        }

        public IEnumerable<Teacher> GetDirector()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var teacher = connection.Query<Teacher>(@"SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director
                                                      FROM Teacher
                                                      WHERE director= 1");
                return teacher;
            }
        }
    }
}

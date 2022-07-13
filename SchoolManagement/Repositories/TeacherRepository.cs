using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using SchoolManagement;
using SchoolManagementEntity;

namespace SchoolManagement.Repositories
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

        public void SetAssignment(int idClasgroup, int idTeacher)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "INSERT INTO Classgroup_Teacher (id_classgroup, id_teacher) VALUES(" + idClasgroup + ", " + idTeacher + ")";

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }
    }
}

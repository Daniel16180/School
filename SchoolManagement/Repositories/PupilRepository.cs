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

namespace SchoolManagement.Repositories
{
    class PupilRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

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

        public IReadOnlyList<Person2DTO> MyMates(int idClass)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();


                var personDTOList = conexion.Query<Person2DTO>(@"SELECT id as Id, first_name as Name, last_name as Surname FROM dbo.Pupil WHERE id_classgroup = " + idClass);
                return personDTOList.ToList().AsReadOnly();
            }
        }


    }
}

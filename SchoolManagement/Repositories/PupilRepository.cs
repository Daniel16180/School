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
    class PupilRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Pupil> GetPupils()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var pupil = connection.Query<Pupil>("SELECT id as Id, first_name as Name, last_name as Surname, age as Age, id_classgroup as IdClassgroup FROM Pupil");
                return pupil;
            }
        }

        public void SetPupil(Pupil p)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Pupil (first_name, last_name, age, id_classgroup) VALUES(@Name, @Surname, @Age, @IdClassgroup)";

                int rowsAffected = connection.Execute(sqlQuery, p);
            }
        }

        public void UpdatePupil(int idPupil, int age, int classId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Pupil
                                    SET age= " + age + ", id_classgroup = " + classId + " " +
                                    "WHERE id= " + idPupil;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeletePupil(int idPupil)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Pupil
                                    WHERE id = " + idPupil;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2DTO> MyMates(int idClass)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();


                var personDTOList = connection.Query<Person2DTO>(@"SELECT id as Id, first_name as Name, last_name as Surname FROM dbo.Pupil WHERE id_classgroup = " + idClass);
                return personDTOList.ToList().AsReadOnly();
            }
        }


    }
}

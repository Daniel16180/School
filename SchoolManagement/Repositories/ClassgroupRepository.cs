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
    class ClassGroupRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<ClassGroup> GetClassgroups()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var classgroup = connection.Query<ClassGroup>("SELECT id as Id, year as Year, letter as Letter FROM Classgroup");
                return classgroup;
            }
        }

        public void SetClassgroup(int year, string letter)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Classgroup (year, letter) VALUES(" + year + ", '" + letter + "')";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void UpdateClassgroup(ClassGroup classGroup)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Classgroup
                                    SET year= " + classGroup.Year + ", letter= '" + classGroup.Letter + "' " +
                                    "WHERE id= " + classGroup.Id;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeleteClassgroup(int identification)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Classgroup
                                    WHERE id = " + identification;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void Merge(int firstGroup, int secondGroup)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE Pupil SET id_classgroup = " + secondGroup + " WHERE id_classgroup = " + firstGroup;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

    }
}

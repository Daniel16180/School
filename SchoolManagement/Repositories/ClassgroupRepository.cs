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
    class ClassgroupRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

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

        public void Merge(int firstGroup, int segondGroup)
        {
            using (IDbConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string sqlQuery = "UPDATE Pupil SET id_classgroup = " + segondGroup + " WHERE id_classgroup = " + firstGroup;

                int rowsAffected = conexion.Execute(sqlQuery);
            }
        }

    }
}

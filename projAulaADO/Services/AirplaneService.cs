using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projAulaADO.Model;
using projAulaADO.Models;

namespace projAulaADO.Services
{
    public class AirplaneService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAulaADO\projAulaADO\DataBase\fly.mdf";
        readonly SqlConnection conn;

        public AirplaneService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Airplane airplane)
        {
            bool status = false;

            try
            {

                string strInsert = "insert into airplane (Name, NumberOfPassengers, Description, IdEngine) values (@Name, @NumberOfPassengers, @Description, @IdEngine)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumberOfPassengers", airplane.NumberOfPassengers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Description));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            { 
                conn.Close(); 
            }

            return status;
        }

        private int InsertEngine(Airplane airplane)
        {
            string strInsert = "insert into Engine (Description) values (@Description); " +
                "Select cast(scope_Identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Engine.Description));
            
            return (int) commandInsert.ExecuteScalar();
        }

        public List<Airplane> FindAll()
        {
            List<Airplane> airplanes = new();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select a.Id, a.Name, a.NumberOfPassengers, a.Description, e.Description as EngineDescription from Airplane a join Engine e on a.IdEngine = e.Id");

            SqlCommand commandSelect = new SqlCommand(stringBuilder.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Airplane airplane = new();

                airplane.Id = (int)reader["Id"];
                airplane.Name = (string)reader["Name"];
                airplane.NumberOfPassengers = (int)reader["NumberOfPassengers"];
                airplane.Description = (string)reader["Description"];
                airplane.Engine = new Engine() { Description = (string)reader["EngineDescription"] };

                airplanes.Add(airplane);
            }

            return airplanes;
        }
    }
}

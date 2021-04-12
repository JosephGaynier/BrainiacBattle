using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BrainiacBattle.Services
{

    public class DatabaseConnection
    {
        private string cString = "Server=tcp:braniacbattle.database.windows.net,1433;Initial Catalog=BrainiacBattle;Persist Security Info=False;User ID=RuntimeTerror;Password=RTRules@97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        public DatabaseConnection()
        {
            con = new SqlConnection(cString);

        }
        public void OpenDatabase()
        {
            con.Open();
        }
        public void CloseDatabase()
        {
            con.Close();
        }
        public SqlConnection GetSqlConnection()
        {
            return con;
        }
        public void SetSqlCommand(string qString)
        {
            cmd = new SqlCommand(qString, con);
        }
        public SqlCommand GetSqlCommand()
        {
            return cmd;
        }
        public void SetDataReader()
        {
            reader = cmd.ExecuteReader();
        }

        public SqlDataReader GetDataReader()
        {
            return reader;
        }
    }
}

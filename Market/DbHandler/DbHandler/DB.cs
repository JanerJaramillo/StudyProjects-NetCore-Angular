using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler.DbHandler
{
    public class DB : DbConnection
    {
        public DB() : base() { }

        public void Execute(Action<MySqlCommand> executeCommand)
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            try
            {
                executeCommand(Command);
            }
            catch (Exception e)
            {
                Log("DB.Execute", e.ToString());
            }
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}

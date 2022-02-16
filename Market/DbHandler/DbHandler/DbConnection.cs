using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DbHandler.DbHandler
{
    public abstract class DbConnection
    {
        protected MySqlConnection Connection;
        protected MySqlCommand Command;

        public DbConnection()
        {
            IDbSettings settings;
            settings = new DbSettingsMarket();
            string connectionString = $"DataSource={settings.Host}; Database={settings.DataBase}; Uid={settings.User}; Pwd={settings.Password};";
            Connection = new MySqlConnection(connectionString);
            Command = new MySqlCommand { Connection = Connection };
        }

        public void Log(string location, string data)
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
            try
            {
                Command.CommandText = $"insert into exeptionlog set location = '{location}', data = '{data.Replace("'", "\\'")}'";
                Command.ExecuteNonQuery();
            }
            catch (Exception) { }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }
    }
}

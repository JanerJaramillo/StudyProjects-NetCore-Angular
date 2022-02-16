using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler.DbHandler
{
    public class DbSettingsMarket : IDbSettings
    {
        public string Host { get; private set; }
        public string DataBase { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }

        public DbSettingsMarket()
        {
            Host = "localhost";
            DataBase = "market";
            User = "root";
            Password = "srgrcp";
        }
    }
}

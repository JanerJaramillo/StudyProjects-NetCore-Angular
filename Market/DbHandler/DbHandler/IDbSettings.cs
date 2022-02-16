using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler.DbHandler
{
    interface IDbSettings
    {
        string Host { get; }
        string DataBase { get; }
        string User { get; }
        string Password { get; }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandler.DbHandler
{
    public class TransactionHandler : DbConnection
    {
        public TransactionHandler() : base() { }

        public bool ExecuteTransaction(Action<MySqlCommand> ExecuteCommands)
        {
            bool success = false;
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            MySqlTransaction transaction = Connection.BeginTransaction();
            Command.Transaction = transaction;
            try
            {
                ExecuteCommands(Command);
                transaction.Commit();
                success = true;
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                    Log("ExecuteTransaction", e.ToString());
                }
                catch (Exception rollbackException)
                {
                    Log("ExecuteTransaction => Rollback", rollbackException.ToString());
                }
            }
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            return success;
        }
    }
}

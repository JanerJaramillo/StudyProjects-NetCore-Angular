using DbHandler.DbHandler;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MarcaModule
{
    public class MarcaDao
    {
        DB db;

        public MarcaDao()
        {
            db = new DB();
        }

        public List<Marca> GetMarcaList()
        {
            List<Marca> marcas = new List<Marca>();
            db.Execute(command =>
            {
                command.Parameters.Clear();
                command.CommandText = "select * from marca";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    marcas.Add(new Marca
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Nombre = reader["nombre"].ToString()
                    });
                }
            });
            return marcas;
        }
    }
}

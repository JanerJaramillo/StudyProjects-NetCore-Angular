using DbHandler.DbHandler;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.CategoriaModule
{
    public class CategoriaDao
    {
        DB db;

        public CategoriaDao()
        {
            db = new DB();
        }

        public List<Categoria> GetCategoriaList()
        {
            List<Categoria> categorias = new List<Categoria>();
            db.Execute(command =>
            {
                command.Parameters.Clear();
                command.CommandText = "select * from categoria";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Nombre = reader["nombre"].ToString()
                    });
                }
            });
            return categorias;
        }
    }
}

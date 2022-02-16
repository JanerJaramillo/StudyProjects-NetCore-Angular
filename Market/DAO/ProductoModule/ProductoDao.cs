using DbHandler.DbHandler;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ProductoModule
{
    public class ProductoDao
    {
        TransactionHandler transactionHandler;
        DB db;

        public ProductoDao()
        {
            transactionHandler = new TransactionHandler();
            db = new DB();
        }

        public Producto InsertProduct(Producto producto)
        {
            transactionHandler.ExecuteTransaction(command =>
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@nombre", producto.Nombre);
                command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@precio", producto.Precio);
                command.Parameters.AddWithValue("@marcaId", producto.MarcaId);
                command.Parameters.AddWithValue("@categoriaId", producto.CategoriaId);
                command.CommandText = "insert into producto set nombre = @nombre, descripcion = @descripcion, " +
                "stock = @stock, precio = @precio, marcaId = @marcaId, categoriaId = @categoriaId";
                command.ExecuteNonQuery();
                producto.Id = command.LastInsertedId;
            });
            return producto;
        }

        public bool UpdateProduct(Producto producto)
        {
            bool success = false;
            success = transactionHandler.ExecuteTransaction(command =>
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", producto.Id);
                command.Parameters.AddWithValue("@nombre", producto.Nombre);
                command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@precio", producto.Precio);
                command.Parameters.AddWithValue("@marcaId", producto.MarcaId);
                command.Parameters.AddWithValue("@categoriaId", producto.CategoriaId);
                command.CommandText = "update producto set nombre = @nombre, descripcion = @descripcion, " +
                "stock = @stock, precio = @precio, marcaId = @marcaId, categoriaId = @categoriaId " +
                "where id = @id";
                command.ExecuteNonQuery();
            });
            return success;
        }

        public bool DeleteProduct(int id)
        {
            bool success = false;
            success = transactionHandler.ExecuteTransaction(command =>
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = "delete from producto where id = @id";
                command.ExecuteNonQuery();
            });
            return success;
        }

        public List<Producto> GetProducts()
        {
            List<Producto> products = new List<Producto>();
            db.Execute(command =>
            {
                command.Parameters.Clear();
                command.CommandText = "select p.id, p.nombre, p.descripcion, p.stock, p.precio, " +
                "m.nombre As marca, c.nombre As categoria from marca m inner join producto p on m.id = p.marcaId " +
                "inner join categoria c on p.categoriaId = c.id order by p.id";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Producto
                    {
                        Id = Convert.ToInt64(reader["id"].ToString()),
                        Nombre = reader["nombre"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Stock = Convert.ToInt32(reader["stock"].ToString()),
                        Precio = Convert.ToDouble(reader["precio"].ToString()),
                        Marca = reader["marca"].ToString(),
                        Categoria = reader["categoria"].ToString()
                    });
                }
            });
            return products;
        }

        public Producto GetProductsForId(long id)
        {
            Producto producto = null;
            db.Execute(command =>
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = "select p.id, p.nombre, p.descripcion, p.stock, p.precio, p.marcaId, p.categoriaId, " +
                "m.nombre As marca, c.nombre As categoria from marca m inner join producto p on m.id = p.marcaId " +
                "inner join categoria c on p.categoriaId = c.id where p.id = @id";
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    producto = new Producto
                    {
                        Id = Convert.ToInt64(reader["id"].ToString()),
                        Nombre = reader["nombre"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Stock = Convert.ToInt32(reader["stock"].ToString()),
                        Precio = Convert.ToDouble(reader["precio"].ToString()),
                        MarcaId = Convert.ToInt32(reader["marcaId"].ToString()),
                        Marca = reader["marca"].ToString(),
                        CategoriaId = Convert.ToInt32(reader["categoriaId"].ToString()),
                        Categoria = reader["categoria"].ToString()
                    };
                }
            });
            return producto;
        }
    }
}

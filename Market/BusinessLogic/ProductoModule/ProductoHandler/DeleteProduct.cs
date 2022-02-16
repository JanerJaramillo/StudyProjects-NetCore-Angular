using DAO.ProductoModule;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductoModule.ProductoHandler
{
    public class DeleteProduct
    {
        public int id { get; set; }

        private ProductoDao productoDao;

        public DeleteProduct()
        {
            productoDao = new ProductoDao();
        }

        public Response<List<Producto>> Run()
        {
            bool success = productoDao.DeleteProduct(id);
            if (!success)
            {
                return new Response<List<Producto>>
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            List<Producto> products = productoDao.GetProducts();
            return new Response<List<Producto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = products
            };
        }
    }
}

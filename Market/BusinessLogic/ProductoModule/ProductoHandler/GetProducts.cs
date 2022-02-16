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
    public class GetProducts
    {
        private ProductoDao productoDao;

        public GetProducts()
        {
            productoDao = new ProductoDao();
        }

        public Response<List<Producto>> Run()
        {
            List<Producto> products = productoDao.GetProducts();
            return new Response<List<Producto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = products
            };
        }
    }
}

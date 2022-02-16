using DAO.ProductoModule;
using Model;
using Model.Entities;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductoModule.ProductoHandler
{
    public class GetProductsForId
    {
        public long id { get; set; }

        private ProductoDao productoDao;

        public GetProductsForId()
        {
            productoDao = new ProductoDao();
        }

        public Response<Producto> Run()
        {
            Producto producto = productoDao.GetProductsForId(id);
            if(producto == null)
            {
                return new Response<Producto>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ErrorCode = ApiErrorCode.DB_ERROR
                };
            }
            return new Response<Producto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = producto
            };
        }
    }
}

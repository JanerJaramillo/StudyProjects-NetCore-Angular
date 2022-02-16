using BusinessLogic.ProductoModule.ProductoHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        [HttpGet]
        public Response<List<Producto>> GetProducts()
        {
            GetProducts getProducts = new GetProducts();
            return getProducts.Run();
        }

        [HttpPost("insertProduct")]
        public Response<Producto> InsertProduct(Producto productos)
        {
            InsertProduct insertProduct = new InsertProduct { productos = productos };
            return insertProduct.Run();
        }

        [HttpPut("updateProduct")]
        public Response<List<Producto>> UpdateProduct(Producto producto)
        {
            UpdateProduct updateProduct = new UpdateProduct { producto = producto };
            return updateProduct.Run();
        }

        [HttpDelete("deleteProduct")]
        public Response<List<Producto>> DeleteProduct([FromQuery]int id)
        {
            DeleteProduct deleteProduct = new DeleteProduct { id = id };
            return deleteProduct.Run();
        }

        [HttpGet("getProductsForId")]
        public Response<Producto> GetProductsForId([FromQuery]long id)
        {
            GetProductsForId getProductsForId = new GetProductsForId { id = id };
            return getProductsForId.Run();
        }
    }
}

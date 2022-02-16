using BusinessLogic.CategoriaModule.CategoriaHandler;
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
    public class CategoriaController : BaseApiController
    {
        [HttpGet]
        public Response<List<Categoria>> GetCategoriaList()
        {
            GetCategoriaList getCategoriaList = new GetCategoriaList();
            return getCategoriaList.Run();
        }
    }
}

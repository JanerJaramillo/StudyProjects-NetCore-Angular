using BusinessLogic.MarcaModule.MarcaHandler;
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
    public class MarcaController : BaseApiController
    {
        [HttpGet]
        public Response<List<Marca>> GetMarcaList()
        {
            GetMarcaList getMarcaList = new GetMarcaList();
            return getMarcaList.Run();
        }
    }
}

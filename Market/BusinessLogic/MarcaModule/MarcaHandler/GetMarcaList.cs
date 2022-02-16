using DAO.MarcaModule;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MarcaModule.MarcaHandler
{
    public class GetMarcaList
    {
        private MarcaDao marcaDao;

        public GetMarcaList()
        {
            marcaDao = new MarcaDao();
        }

        public Response<List<Marca>> Run()
        {
            List<Marca> marcas = marcaDao.GetMarcaList();
            return new Response<List<Marca>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = marcas
            };
        }
    }
}

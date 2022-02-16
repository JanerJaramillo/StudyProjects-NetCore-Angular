using DAO.CategoriaModule;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CategoriaModule.CategoriaHandler
{
    public class GetCategoriaList
    {
        private CategoriaDao categoriaDao;

        public GetCategoriaList()
        {
            categoriaDao = new CategoriaDao();
        }

        public Response<List<Categoria>> Run()
        {
            List<Categoria> categorias = categoriaDao.GetCategoriaList();
            return new Response<List<Categoria>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = categorias
            };
        }
    }
}

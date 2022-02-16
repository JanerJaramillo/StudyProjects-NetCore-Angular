using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Producto
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public double Precio { get; set; }

        public int MarcaId { get; set; }

        public string Marca { get; set; }

        public int CategoriaId { get; set; }

        public string Categoria { get; set; }
    }
}

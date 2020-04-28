using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Categoria
    {
        public int IDCategoria { get; set; }
        public string DescripcionCategoria { get; set; }

        // Este override nos trae los tipos de categoria si no queria dominio.tipo
        public override string ToString()
        {

            return DescripcionCategoria;
        }


        

    }

}

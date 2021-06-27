using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dbo
{
    public class DepartamentosEntity : EN
    {

        public int? IdDepartamento { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }
}

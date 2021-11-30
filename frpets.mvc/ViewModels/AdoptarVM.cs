using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class AdoptarVM
    {
        public int IdAdoptar { get; set; }
        public int IdAdministrador { get; set; }
        public int IdUsuario { get; set; }
        public string DocumentoAdoptar { get; set; }
        public int EstadoAdoptar { get; set; }
    }
}

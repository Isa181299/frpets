using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class MascotaVM
    {
        public int IdMascota { get; set; }
        public string NombreMascota { get; set; }
        public string SexoMascota { get; set; }
        public string TamañoMascota { get; set; }
        public byte EdadMascota { get; set; }
        public int IdTipo { get; set; }
        public int EstadoMascota { get; set; }
        public string FotoMascota { get; set; }
        public int IdUsuario { get; set; }
    }
}

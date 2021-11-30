using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class UsuarioVM
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string CelularUsuario { get; set; }
        public string DirecciónUsuario { get; set; }
        public int IdPais { get; set; }
        public DateTime FechaNacimientoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string ContraseñaUsuario { get; set; }
        public bool? GeneroUsuario { get; set; }
        public string FotoUsuario { get; set; }
        public int EstadoUsuario { get; set; }
    }
}

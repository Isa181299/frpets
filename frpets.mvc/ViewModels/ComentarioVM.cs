using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class ComentarioVM
    {
        public int IdComentario { get; set; }
        public int IdUsuario { get; set; }
        public string DetalleComentario { get; set; }
        public int EstadoComentario { get; set; }
    }
}

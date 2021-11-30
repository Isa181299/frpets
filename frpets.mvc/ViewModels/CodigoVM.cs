using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class CodigoVM
    {
        public int IdCodigo { get; set; }
        public string DatoCodigo { get; set; }
        public int CantidadCodigo { get; set; }
        public byte EstadoCodigo { get; set; }
        public int IdSponsor { get; set; }
    }
}

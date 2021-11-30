using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frpets.mvc.ViewModels
{
    public class SponsorVM
    {
        public int IdSponsor { get; set; }
        public string NombreSponsor { get; set; }
        public string UrlSponsor { get; set; }
        public string LogoSponsor { get; set; }
        public int EstadoSponsor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models.ViewModel
{
    public class DonoViewModel
    {
        public Dono Dono { get; set; }
        public Email Email { get; set; }
        public Contacto Contacto { get; set; }
        public Morada Morada { get; set; }
        public Pais Pais { get; set; }
        public Distrito Distrito { get; set; }
    }
}

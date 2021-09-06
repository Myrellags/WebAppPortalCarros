using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    public class BaseEntity
    {
        public bool? Ativo { get; set; }
        public bool? Delete { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}

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
        public ICollection<Email> Emails { get; set; }
        public static DonoViewModel GetDonoVM (Dono dono)
        {
            DonoViewModel donoViewModel = new DonoViewModel();
            donoViewModel.Dono = dono;
            //donoViewModel.Email = (Email)dono.Emails;
            donoViewModel.Emails = dono.Emails;
            //donoViewModel.Contacto = (Contacto)dono.Contactos;
            //donoViewModel.Morada = (Morada)dono.Moradas;
            //donoViewModel.Morada = dono.Moradas;
            return donoViewModel;
        }
    }
}

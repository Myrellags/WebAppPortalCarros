using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Donos")]
    [Index(nameof(DonoID), IsUnique = true)]
    public class Dono : BaseEntity
    {
        [Key]
        public int DonoID { get; set; }
        [StringLength(9)]
        [Display(Name = "NIF")]
        public string NIF { get; set; }
        [StringLength(200)]
        [Display(Name = "Proprietário")]
        public string Nome { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Morada> Moradas { get; set; }
    }
}

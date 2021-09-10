using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Clientes")]
    [Index(nameof(ClienteID), IsUnique = true)]
    public class Cliente : BaseEntity
    {
        #region Atributos Cliente
        [Key]
        public int ClienteID { get; set; }
        [StringLength(9)]
        [Display(Name = "NIF")]
        public string NIF { get; set; }
        
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Morada> Moradas { get; set; }
        #endregion
    }
}

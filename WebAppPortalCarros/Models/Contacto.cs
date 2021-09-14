using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Contactos")]
    [Index(nameof(ContactoID), IsUnique = true)]
    public class Contacto : BaseEntity
    {
        #region "Atributos Contacto"
        [Key]
        public int ContactoID { get; set; }
        [ForeignKey("Dono")]
        public int? DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Sufixo de Contacto.")]
        [StringLength(3)]
        [Display(Name = "Suf.")]
        public string SufixoContacto { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Número de Contacto.")]
        [StringLength(10)]
        [Display(Name = "Contacto")]
        public string NumeroContacto { get; set; }
        #endregion
    }
}

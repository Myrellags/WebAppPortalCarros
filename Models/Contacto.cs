using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
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
        [ForeignKey("Cliente")]
        public int? ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Sufixo de Contacto.")]
        [StringLength(5)]
        [Display(Name = "Suf.")]
        public string SufixoContacto { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Número de Contacto.")]
        [StringLength(15)]
        [Display(Name = "Contacto")]
        public string NumeroContacto { get; set; }
        #endregion
    }
}

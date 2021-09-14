using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Moradas")]
    [Index(nameof(MoradaID), IsUnique = true)]
    public class Morada : BaseEntity
    {
        #region "Atributos Morada"
        [Key]
        public int MoradaID { get; set; }
        [ForeignKey("Dono")]
        public int? DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [StringLength(150)]
        public string Rua { get; set; }
        [StringLength(6)]
        [Display(Name = "Nº")]
        public string Numero { get; set; }
        [ForeignKey("Distrito")]
        [Display(Name = "Distrito")]
        public int DistritoID { get; set; }
        public virtual Distrito Distrito { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Código Postal.")]
        [StringLength(9)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }
        [StringLength(250)]
        [Display(Name = "País")]
        public string Pais { get; set; }
        #endregion
    }
}

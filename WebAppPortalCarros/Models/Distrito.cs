using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Distritos")]
    [Index(nameof(DistritoID), IsUnique = true)]
    public class Distrito : BaseEntity
    {
        #region "Atributos Distritos"
        [Key]
        public int DistritoID { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Distrito")]
        [StringLength(50)]
        [Display(Name = "Distrito")]
        public string NomeDistrito { get; set; }
        [ForeignKey("Pais")]
        [Display(Name = "Pais")]
        public int PaisID { get; set; }
        public virtual Pais Pais { get; set; }
        #endregion
    }
}

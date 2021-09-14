using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Paises")]
    [Index(nameof(PaisID), IsUnique = true)]
    public class Pais : BaseEntity
    {
        #region "Atributos pais"
        [Key]
        public int PaisID { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Pais")]
        [StringLength(250)]
        [Display(Name = "Pais")]
        public string NomePais { get; set; }
        #endregion
    }
}

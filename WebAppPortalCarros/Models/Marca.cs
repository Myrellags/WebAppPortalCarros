using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Marcas")]
    [Index(nameof(MarcaID), IsUnique = true)]
    public class Marca : BaseEntity
    {
        #region "Atributos Marca"
        [Key]
        public int MarcaID { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Nome da Marca")]
        [StringLength(50)]
        [Display(Name = "Marca")]
        public string NomeMarca { get; set; }
        #endregion
    }
}

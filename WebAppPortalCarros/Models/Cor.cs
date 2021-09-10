using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Cores")]
    [Index(nameof(CorID), IsUnique = true)]
    public class Cor : BaseEntity
    {
        #region "Atributos Cor"
        [Key]
        public int CorID { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Nome da Cor")]
        [StringLength(50)]
        [Display(Name = "Cor")]
        public string NomeCor { get; set; }
        public string PaletaCodigo { get; set; }
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Unidades")]
    [Index(nameof(UnidadeID), IsUnique = true)]
    public class Unidade : BaseEntity
    {
        #region "Atributos Unidade"
        [Key]
        public int UnidadeID { get; set; }
        [Required(ErrorMessage = "Por favor entre com a Unidade de Medida")]
        [StringLength(50)]
        [Display(Name = "Unidade de medida")]
        public string NomeUnidade { get; set; }
        #endregion
    }
}

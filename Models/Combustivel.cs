using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("Combustiveis")]
    [Index(nameof(CombustivelID), IsUnique = true)]
    public class Combustivel : BaseEntity
    {
        #region "Atributos Combustivel"
        [Key]
        public int CombustivelID { get; set; }
        [Required(ErrorMessage = "Por favor entre com o Combustível")]
        [StringLength(50)]
        [Display(Name = "Combustível")]
        public string NomeCombustivel { get; set; }
        [ForeignKey("Unidade")]
        [Display(Name = "Unidade de Medida")]
        public int UnidadeID { get; set; }
        public virtual Unidade Unidade { get; set; }
        #endregion
    }
}

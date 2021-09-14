using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Valores")]
    [Index(nameof(ValorID), IsUnique = true)]
    public class Valor : BaseEntity
    {
        #region Atributos Valor
        [Key]
        public int ValorID { get; set; }
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*,\d{ 2}$")]
        public float PrecoID { get; set; }
        [ForeignKey("Carro")]
        [Display(Name = "Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        #endregion
    }
}

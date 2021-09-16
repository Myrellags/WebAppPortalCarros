using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Anos")]
    [Index(nameof(AnoID), IsUnique = true)]
    public class Ano : BaseEntity
    {
        #region "Atributos Ano"
        [Key]
        public int AnoID { get; set; }
        public string AnoValor { get; set; }
        [ForeignKey("Carro")]
        [Display(Name = "Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        #endregion
    }
}

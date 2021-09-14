using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Compras")]
    [Index(nameof(CompraID), IsUnique = true)]
    public class Compra : BaseEntity
    {
        #region Atributos Compra
        [Key]
        public int CompraID { get; set; }
        [ForeignKey("Dono")]
        [Display(Name = "Proprietário")]
        public int DonoID { get; set; }
        public virtual Dono Dono { get; set; }        
        [ForeignKey("Carro")]
        [Display(Name = "Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        #endregion
    }
}

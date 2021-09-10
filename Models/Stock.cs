using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("Stocks")]
    [Index(nameof(StockID), IsUnique = true)]
    public class Stock
    {
        #region "Atributos Stock
        [Key]
        public int StockID { get; set; }
        [ForeignKey("Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        public int Quantidade { get; set; }
        #endregion
    }
}

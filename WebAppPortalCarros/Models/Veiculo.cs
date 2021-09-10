using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Veiculos")]
    [Index(nameof(VeiculoID), IsUnique = true)]
    public class Veiculo
    {
        #region "Atributos Veiculo
        [Key]
        public int VeiculoID { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string Tipo { get; set; }
        #endregion
    }
}

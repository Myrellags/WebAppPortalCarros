using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("Modelos")]
    [Index(nameof(ModeloID), IsUnique = true)]
    public class Modelo : BaseEntity
    {
        #region "Atributos Modelo"
        [Key]
        public int ModeloID { get; set; }
        [Required(ErrorMessage = "Por favor entre com Modelo do Carro")]
        [StringLength(50)]
        [Display(Name = "Modelo")]
        public string Nomemodelo { get; set; }
        [ForeignKey("Marca")]
        [Display(Name = "Marca")]
        public int MarcaID { get; set; }
        public virtual Marca Marca { get; set; }
        #endregion
    }
}

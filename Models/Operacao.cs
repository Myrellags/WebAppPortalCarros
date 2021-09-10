using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("Operacoes")]
    [Index(nameof(OperacaoID), IsUnique = true)]
    public class Operacao : BaseEntity
    {
        #region Atributos Operacao
        [Key]
        public int OperacaoID { get; set; }
        public string NomeOperacao { get; set; }
        [ForeignKey("Carro")]
        [Display(Name = "Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        #endregion
    }
}

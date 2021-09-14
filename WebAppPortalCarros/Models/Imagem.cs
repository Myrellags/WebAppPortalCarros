using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Imagens")]
    [Index(nameof(ImagemID), IsUnique = true)]
    public class Imagem : BaseEntity
    {
        #region "Atributos Email"
        [Key]
        public int ImagemID { get; set; }
        public byte[] Image { get; set; }
        public byte[] Video { get; set; }
        public byte[] Matricula { get; set; }
        [ForeignKey("Dono")]
        public int? DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [ForeignKey("Carro")]
        public int? CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        #endregion
    }
}

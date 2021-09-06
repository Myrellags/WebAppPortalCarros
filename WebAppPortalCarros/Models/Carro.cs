using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Carros")]
    [Index(nameof(CarroID), IsUnique = true)]
    public class Carro : BaseEntity
    {
        [Key]
        public int CarroID { get; set; }
        [StringLength(10)]
        [Display(Name = "Matricula")]
        public string Matricula { get; set; }
        [StringLength(4)]
        [Display(Name = "Ano")]
        public DateTime Ano { get; set; }
        [StringLength(2)]
        [Display(Name = "Mês")]
        public string Mes { get; set; }
        [StringLength(30)]
        [Display(Name = "Cor")]
        public string Cor { get; set; }
        [StringLength(20)]
        [Display(Name = "Tipo de combustível")]
        public string Combustível { get; set; }
        [ForeignKey("Dono")]
        [Display(Name = "Proprietário")]
        public int DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [StringLength(20)]
        [Display(Name = "marca")]
        public string Marca { get; set; }
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }
        [StringLength(30)]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
    }
}

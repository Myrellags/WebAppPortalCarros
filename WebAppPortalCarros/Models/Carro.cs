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
        [StringLength(8)]
        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "A Matrícula do Carro é obrigatória.", AllowEmptyStrings = false)]
        
        public string Matricula { get; set; }
        [StringLength(2)]
        [Display(Name = "Mês")]
        public string Mes { get; set; }
        [ForeignKey("Cor")]
        [Display(Name = "Cor")]
        public int CorID { get; set; }
        public virtual Cor Cor { get; set; }
        [ForeignKey("Combustivel")]
        [Display(Name = "Combustivel")]
        public int CombustivelID { get; set; }
        public virtual Combustivel Combustivel { get; set; }
        [ForeignKey("Dono")]
        [Display(Name = "Proprietário")]
        [Required(ErrorMessage = "Por favor escolha um dono.")]
        public int DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [Display(Name = "marca")]
        public string Marca { get; set; }
        [ForeignKey("Modelo")]
        [Display(Name = "Modelo")]
        public int ModeloID { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual ICollection<Valor> Valores { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }

    }


    
}

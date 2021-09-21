using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models.ViewModel
{
    public class CarroViewModel
    {
        [Key]
        public int CarroID { get; set; }
        //[StringLength(8)]
        [Display(Name = "Matricula:")]
        [Required(ErrorMessage = "A Matrícula do Carro é obrigatória.", AllowEmptyStrings = false)]
       // [RegularExpression(@"\w\w-\d{2}-\d{2}", ErrorMessage = "A Matrícula deve obedecer ao padrão: 00-00-00.")]
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
        public int DonoID { get; set; }
        public virtual DonoViewModel Dono { get; set; }
        [Display(Name = "marca")]
        public string Marca { get; set; }
        [ForeignKey("Modelo")]
        [Display(Name = "Modelo")]
        public int ModeloID { get; set; }
        public virtual Modelo Modelo { get; set; }

        public Ano Ano { get; set; }
        public Imagem Imagem { get; set; }
    }
}

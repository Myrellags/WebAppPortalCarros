using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Donos")]
    [Index(nameof(DonoID), IsUnique = true)]
    public class Dono : BaseEntity
    {
        #region Atributos Dono
        [Key]
        public int DonoID { get; set; }
        [StringLength(9)]
        [Display(Name = "NIF")]
        [RegularExpression("^[0-9]+$",
         ErrorMessage = "Apenas números são permitidos.")]
        public string NIF { get; set; }
        [StringLength(250)]
        [Display(Name = "Proprietário")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Caracteres especiais não são permitidos.")]
        public string Nome { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Morada> Moradas { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        #endregion
    }
}

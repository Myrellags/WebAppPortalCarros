using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Emails")]
    [Index(nameof(EmailID), IsUnique = true)]
    public class Email : BaseEntity
    {
        #region "Atributos Email "
        [Key]
        public int EmailID { get; set; }
        [ForeignKey("Dono")]
        public int? DonoID { get; set; }
        //public virtual Dono Dono { get; set; }
        [StringLength(250)]
        
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido…")]
        [Display(Name = "E-mail")]
        public string EmailDono { get; set; }
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("Emails")]
    [Index(nameof(EmailID), IsUnique = true)]
    public class Email : BaseEntity
    {
        #region "Atributos Email Cliente"
        [Key]
        public int EmailID { get; set; }
        [ForeignKey("Dono")]
        public int? DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [ForeignKey("Cliente")]
        public int? ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "Por favor entre com o E-mail.")]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string EmailDono { get; set; }
        #endregion
    }
}

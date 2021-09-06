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
        #region "Atributos Email Cliente"
        [Key]
        public int EmailID { get; set; }
        [ForeignKey("Cliente")]
        public int DonoID { get; set; }
        public virtual Dono Dono { get; set; }
        [Required(ErrorMessage = "Por favor entre com o E-mail.")]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string EmailDono { get; set; }
        #endregion
    }
}

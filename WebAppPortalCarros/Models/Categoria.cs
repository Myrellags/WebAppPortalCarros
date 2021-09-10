using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models
{
    [Table("Categorias")]
    [Index(nameof(CategoriaID), IsUnique = true)]
    public class Categoria
    {
        #region "Atributos Categoria
        [Key]
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        #endregion
    }
}

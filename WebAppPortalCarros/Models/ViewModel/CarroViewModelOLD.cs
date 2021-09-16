using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Models.ViewModel
{
    public class CarroViewModelOLD
    {
        public Carro Carro { get; set; }
        public Ano Ano { get; set; }
        public DonoViewModel Dono { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cor Cor { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Marca { get; set; }
        [Display(Name = "Imagem")]
        [DataType(DataType.Upload)]
        public IFormFile ImageUpload { get; set; }
    }
}

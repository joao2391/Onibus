using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onibus.Models
{
    public class Carro
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Insira uma placa")]
        [DisplayName("Placa")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Insira um ano")]
        [DisplayName("Ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Insira uma marca")]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Insira um modelo")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }



    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onibus.Models
{
    public class Passageiro
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira um Rg")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Insira uma data de nascimento")]
        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Nascimento { get; set; }


    }
}
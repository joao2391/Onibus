﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onibus.Models
{
    public class Motorista
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira um Cpf")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira uma cnh")]
        [DisplayName("CNH")]
        public string Cnh { get; set; }



    }
}
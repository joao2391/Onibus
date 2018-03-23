using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onibus.Models
{
    public class Viagem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um destino")]
        [DisplayName("Destino")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Insira uma data")]
        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Insira um onibus")]
        [DisplayName("Onibus")]
        public int OnibusId { get; set; }

        [Required(ErrorMessage = "Insira um motorista")]
        [DisplayName("Motorista")]
        public int MotoristaId { get; set; }

        public virtual Carro Onibus { get; set; }
        public virtual Motorista Motorista { get; set; }
        public virtual ICollection<Passageiro> Passageiros { get; set; }


    }
}
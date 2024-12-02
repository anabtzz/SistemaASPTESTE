﻿using System.ComponentModel.DataAnnotations;

namespace Norget.Models
{
    public class NotaFiscal
    {
        public int NF { get; set; }

        [Required]
        public decimal TotalNota { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        public Venda Venda { get; set; }
    }

}

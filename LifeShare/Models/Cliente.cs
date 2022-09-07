using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LifeShare.Models
{
    [Table("Tb_Cliente")]
    public class Cliente
    {

        [Column("Id"),HiddenInput]
        public int ClienteId { get; set; }
        [MaxLength(80)]
        public string Nome { get; set; }
        [Column("Dt_Entrada"), DataType(DataType.Date), Display(Name = "Data de Entrada")]
        public DateTime DataEntrada{ get; set; }
        [Column("Dt_Saida"), DataType(DataType.Date), Display(Name = "Data de Saída")]
        public DateTime DataSaida { get; set; }
        public string Placa { get; set; }
        [Column("Cor_Carro")]
        public CorCarro CorCarro { get; set; }

    }
}

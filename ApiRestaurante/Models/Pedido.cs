using ApiRestaurante.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Models
{
    public class Pedido : BaseModel
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Cliente")]
        public int ID_CLIENTE { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Número da Mesa")]
        public int NR_MESA { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Valor do Pedido")]
        public decimal VL_TOTAL { get; set; }

        [Display(Name = "Pedido está finalizado?")]
        public bool? IsFinalizado { get; set; }
    }
}
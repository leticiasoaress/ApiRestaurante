using ApiRestaurante.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Models
{
    public class ItemPedido : BaseModel
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Pedido")]
        public int ID_PEDIDO { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Produto")]
        public int ID_PRODUTO { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Quantidade")]
        public int QTD { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Valor do Total Item")]
        public decimal VL_ITEM { get; set; }
    }
}
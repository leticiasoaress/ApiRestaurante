using ApiRestaurante.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Models
{
    public class Cliente : BaseModel
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(20, ErrorMessage = "{0} suporta no máximo {1} caracteres")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(250, ErrorMessage = "{0} suporta no máximo {1} caracteres")]
        [Display(Name = "Nome")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DT_NASCIMENTO { get; set; }
    }
}
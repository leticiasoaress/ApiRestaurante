using ApiRestaurante.Base;
using ApiRestaurante.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestaurante.Controllers
{
    public class InformacaoController : ApiController
    {
        private readonly Contexto contexto;
        private readonly RestauranteDataContext dtc;

        public InformacaoController()
        {
            contexto = new Contexto();
            dtc = new RestauranteDataContext();
        }

        public IHttpActionResult GetInformacao()
        {
            List<VW_LISTAR_INFORMACOES> lstInformacao = dtc.VW_LISTAR_INFORMACOES.ToList();

            if (lstInformacao.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstInformacao);
        }
    }
}

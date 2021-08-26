using ApiRestaurante.Base;
using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestaurante.Controllers
{
    public class ValidarController : ApiController
    {
        private readonly Contexto contexto;
        private readonly BaseRepositorio<Cliente> clienteRep;
        private readonly BaseRepositorio<Pedido> pedidoRep;

        public ValidarController()
        {
            contexto = new Contexto();
            clienteRep = new BaseRepositorio<Cliente>();
            pedidoRep = new BaseRepositorio<Pedido>();
        }

        [Route("api/Validar/{cpf}")]
        public IHttpActionResult GetValidar(string cpf)
        {
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            if (cpf == "" || cpf == null)
            {
                return BadRequest("O CPF não pode ser nulo");
            }
            Cliente cliente = clienteRep.GetAll().Where(m => m.CPF == cpf).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [Route("api/Validar/{id}")]
        public IHttpActionResult PutValidar(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (pedidoRep.VerifyId(id) == 0)
            {
                return NotFound();
            }
            pedido.IsFinalizado = true;
            pedidoRep.Update(pedido);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

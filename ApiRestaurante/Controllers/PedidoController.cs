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
    public class PedidoController : ApiController
    {
        private readonly Contexto contexto;
        private readonly BaseRepositorio<Pedido> pedidoRep;
        private readonly BaseRepositorio<Cliente> clienteRep;
        private static int IdCliente;

        public PedidoController()
        {
            contexto = new Contexto();
            pedidoRep = new BaseRepositorio<Pedido>();
            clienteRep = new BaseRepositorio<Cliente>();
        }

        public IHttpActionResult PostProduto(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pedidoRep.Create(pedido);
            return CreatedAtRoute("DefaultApi", new { id = pedido.ID }, pedido);
        }

        public IHttpActionResult GetProduto(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Pedido pedido = pedidoRep.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        public IHttpActionResult GetProduto()
        {
            List<Pedido> lstPedido = pedidoRep.GetAll().ToList();
            if (lstPedido.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstPedido);
        }

        public IHttpActionResult PutProduto(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (pedidoRep.VerifyId(id) == 0)
            {
                return NotFound();
            }

            pedidoRep.Update(pedido);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteProduto(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Pedido pedido = pedidoRep.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedidoRep.Delete(pedido);
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Pedido/SalvarIdCliente/{id}")]
        public IHttpActionResult SalvarIdCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Cliente cliente = clienteRep.GetById(id);
            if (cliente != null)
            {
                IdCliente = cliente.ID;
                return Ok(cliente);              
            }
            return NotFound();
        }
    }
}

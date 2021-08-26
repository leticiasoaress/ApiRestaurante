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
    public class ClienteController : ApiController
    {
        private readonly Contexto contexto;
        private readonly BaseRepositorio<Cliente> clienteRep;

        public ClienteController()
        {
            contexto = new Contexto();
            clienteRep = new BaseRepositorio<Cliente>();
        }

        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clienteRep.Create(cliente);
            return CreatedAtRoute("DefaultApi", new { id = cliente.ID }, cliente);
        }

        public IHttpActionResult GetCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Cliente cliente = clienteRep.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        public IHttpActionResult GetCliente()
        {
            List<Cliente> lstCliente = clienteRep.GetAll().ToList();
            if (lstCliente.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstCliente);
        }

        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (clienteRep.VerifyId(id) == 0)
            {
                return NotFound();
            }

            clienteRep.Update(cliente);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Cliente cliente = clienteRep.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            clienteRep.Delete(cliente);
            return StatusCode(HttpStatusCode.OK);
        }
    }
}

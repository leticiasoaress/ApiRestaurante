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
    public class ProdutoController : ApiController
    {
        private readonly Contexto contexto;
        private readonly BaseRepositorio<Produto> produtoRep;

        public ProdutoController()
        {
            contexto = new Contexto();
            produtoRep = new BaseRepositorio<Produto>();
        }

        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            produtoRep.Create(produto);
            return CreatedAtRoute("DefaultApi", new { id = produto.ID }, produto);
        }

        public IHttpActionResult GetProduto(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Produto produto = produtoRep.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        public IHttpActionResult GetProduto()
        {
            List<Produto> lstProduto = produtoRep.GetAll().ToList();
            if (lstProduto.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstProduto);
        }

        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (produtoRep.VerifyId(id) == 0)
            {
                return NotFound();
            }

            produtoRep.Update(produto);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteProduto(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            Produto produto = produtoRep.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }

            produtoRep.Delete(produto);
            return StatusCode(HttpStatusCode.OK);
        }
    }
}

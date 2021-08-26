using ApiRestaurante.Base;
using ApiRestaurante.DataSource;
using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestaurante.Controllers
{
    public class ItemPedidoController : ApiController
    {
        private readonly Contexto contexto;
        private readonly BaseRepositorio<ItemPedido> itemPedidoRep;
        private readonly BaseRepositorio<Pedido> pedidoRep;
        private readonly BaseRepositorio<Produto> produtoRep;
        private readonly RestauranteDataContext dtc;

        public ItemPedidoController()
        {
            contexto = new Contexto();
            itemPedidoRep = new BaseRepositorio<ItemPedido>();
            dtc = new RestauranteDataContext();
            pedidoRep = new BaseRepositorio<Pedido>();
            produtoRep = new BaseRepositorio<Produto>();
        }

        public IHttpActionResult PostItemPedido(ItemPedido item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Pedido pedido = pedidoRep.GetById(item.ID_PEDIDO);
            if(pedido == null)
            {
                return BadRequest("Pedido não encontrado");
            }
            Produto produto = produtoRep.GetById(item.ID_PRODUTO);
            if(produto == null)
            {
                return BadRequest("Produto não encontrado");
            }

            pedido.VL_TOTAL += (item.VL_ITEM * item.QTD);
            pedidoRep.Update(pedido);

            itemPedidoRep.Create(item);
            return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        }

        public IHttpActionResult GetItemPedido(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            ItemPedido item = itemPedidoRep.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public IHttpActionResult GetItemPedido()
        {
            List<VW_LISTA_ITEM_PEDIDO> lstItemPedido = dtc.VW_LISTA_ITEM_PEDIDO.ToList();

            if (lstItemPedido.Count == 0)
            {
                return NotFound();
            }
            return Ok(lstItemPedido);
        }

        public IHttpActionResult PutItemPedido(int id, ItemPedido item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (itemPedidoRep.VerifyId(id) == 0)
            {
                return NotFound();
            }

            itemPedidoRep.Update(item);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteItemPedido(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O Id deve ser maior que 0");
            }
            ItemPedido item = itemPedidoRep.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            Pedido pedido = pedidoRep.GetById(item.ID_PEDIDO);
            pedido.VL_TOTAL -= (item.VL_ITEM * item.QTD);
            pedidoRep.Update(pedido);

            itemPedidoRep.Delete(item);
            return StatusCode(HttpStatusCode.OK);
        }
    }
}

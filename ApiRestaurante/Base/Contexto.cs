using ApiRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Base
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Conexao")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Cria o BD caso ele não exista !!
            Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());

            //Remove do Entity a geração das tabelas com plural !!
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
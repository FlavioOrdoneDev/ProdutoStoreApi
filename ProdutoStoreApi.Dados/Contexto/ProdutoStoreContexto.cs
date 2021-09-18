using Microsoft.EntityFrameworkCore;
using ProdutoStoreApi.Dados.Mapeamentos;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dados.Contexto
{
    public class ProdutoStoreContexto : DbContext 
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public ProdutoStoreContexto(DbContextOptions<ProdutoStoreContexto> opcoes) : base(opcoes) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());            
        }
    }
}

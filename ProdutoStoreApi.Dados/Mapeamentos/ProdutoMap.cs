using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dados.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Descricao).HasMaxLength(250).IsRequired(true);
            builder.Property(p => p.Ativo).IsRequired(true);
            builder.Property(p => p.Perecivel).IsRequired(true);
            builder.HasOne(p => p.Categoria).WithMany(r => r.Produtos).HasForeignKey(r => r.CategoriaId).IsRequired(true);
            builder.Ignore(p => p.ResultadoValidacao);

            builder.ToTable("tblProduto");
        }
    }
}

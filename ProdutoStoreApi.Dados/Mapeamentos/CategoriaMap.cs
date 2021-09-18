using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dados.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired(true);
            builder.Property(c => c.Descricao).HasMaxLength(250).IsRequired(true);
            builder.Property(c => c.Ativo).IsRequired(true);
            builder.HasMany(c => c.Produtos).WithOne(c => c.Categoria).HasForeignKey(c => c.Id);
            builder.Ignore(c => c.ResultadoValidacao);

            builder.ToTable("tblCategoriaProduto");
        }
    }
}

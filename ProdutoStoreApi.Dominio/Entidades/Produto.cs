using FluentValidation.Results;
using ProdutoStoreApi.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdutoStoreApi.Dominio.Entidades
{
    public class Produto
    {

        public Produto(){}

        public Produto(string nome, string descricao, bool ativo, bool perecivel, int categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Perecivel = perecivel;
            CategoriaId = categoriaId;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public bool Perecivel { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public void SetarAtivo(bool valor)
        {
            Ativo = valor;
        }
        
        public void SetarPerecivel(bool valor)
        {
            Perecivel = valor;
        }

        public bool IsValid()
        {
            ProdutoValidador produtoConsistente = new ProdutoValidador();
            ResultadoValidacao = produtoConsistente.Validate(this);

            return ResultadoValidacao.IsValid;
        }

        [NotMapped]
        public ValidationResult ResultadoValidacao { get; set; }
    }
}

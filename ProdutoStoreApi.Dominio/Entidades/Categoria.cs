using FluentValidation.Results;
using ProdutoStoreApi.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdutoStoreApi.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria(){}
        public Categoria(string nome, string descricao){
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public void SetarNome(string nome)
        {
            Nome = nome;
        }

        public void SetarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetarAtivo(bool valor)
        {
            Ativo = valor;
        }

        public bool IsValid()
        {
            CategoriaValidador categoriaConsistente = new CategoriaValidador();
            ResultadoValidacao = categoriaConsistente.Validate(this);

            return ResultadoValidacao.IsValid;
        }

        [NotMapped]
        public ValidationResult ResultadoValidacao { get; set; }
    }
}

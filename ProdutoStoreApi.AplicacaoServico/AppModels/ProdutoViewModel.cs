using FluentValidation.Results;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            
        }

        public ProdutoViewModel(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Ativo = produto.Ativo;
            Perecivel = produto.Perecivel;
            CategoriaId = produto.CategoriaId;
            Categoria = produto.Categoria;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public bool Perecivel { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public ValidationResult ResultadoValidacao { get; set; }
    }
}

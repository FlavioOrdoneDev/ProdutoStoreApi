using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppModels
{
    public class CategoriaViewModel
    {

        public CategoriaViewModel()
        {

        }

        public CategoriaViewModel(Categoria categoria)
        {
            IdCategoria = categoria.Id;
            Nome = categoria.Nome;
            Descricao = categoria.Descricao;
            Ativo = categoria.Ativo;
            //Produtos = categoria.Produtos.Select(produto => new ProdutoViewModel(produto)).ToList();
        }

        public int IdCategoria { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<ProdutoViewModel> Produtos { get; private set; }
    }
}

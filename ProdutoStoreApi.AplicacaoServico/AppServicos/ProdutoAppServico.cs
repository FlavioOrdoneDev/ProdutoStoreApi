using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppServicos
{
    public class ProdutoAppServico : IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public ProdutoViewModel Adicionar(Produto produto)
        {
            var resultado = _produtoServico.Adicionar(produto);

            return new ProdutoViewModel(resultado);
        }

        public ProdutoViewModel Atualizar(Produto produto)
        {
            var resultado = _produtoServico.Atualizar(produto);

            return new ProdutoViewModel(resultado);
        }

        public ProdutoViewModel ObterPorId(int id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return new ProdutoViewModel(produto);
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            var produtos = _produtoServico.ObterTodos();

            var produtoViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtoViewModel.Add(new ProdutoViewModel(produto));
            }

            return produtoViewModel;
        }

        public ProdutoViewModel Remover(Produto produto)
        {
            var resultado = _produtoServico.Remover(produto);
            return new ProdutoViewModel(resultado);
        }
    }
}

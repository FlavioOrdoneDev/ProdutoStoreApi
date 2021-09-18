using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Repositorios;
using ProdutoStoreApi.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto produto)
        {
            if (!produto.IsValid())
            {
                return produto;
            }

            return _produtoRepositorio.Adicionar(produto);
        }

        public Produto Atualizar(Produto produto)
        {
            if (!produto.IsValid())
            {
                return produto;
            }

            return _produtoRepositorio.Atualizar(produto);
        }

        public Produto ObterPorId(int id)
        {
            return _produtoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }

        public Produto Remover(Produto produto)
        {
            return _produtoRepositorio.Remover(produto);
        }
    }
}

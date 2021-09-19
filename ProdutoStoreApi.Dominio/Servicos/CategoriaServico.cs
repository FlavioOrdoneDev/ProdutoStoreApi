using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Repositorios;
using ProdutoStoreApi.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public Categoria Adicionar(Categoria categoria)
        {
            if (!categoria.IsValid())
            {
                return categoria;
            }

            categoria.Ativo = true;

            return _categoriaRepositorio.Adicionar(categoria);
        }

        public Categoria Atualizar(Categoria categoria)
        {
            if (!categoria.IsValid())
            {
                return categoria;
            }

            return _categoriaRepositorio.Atualizar(categoria);
        }

        public Categoria ObterPorId(int id)
        {
            return _categoriaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Categoria> ObterTodas()
        {
            return _categoriaRepositorio.ObterTodas();
        }

        public Categoria Remover(Categoria categoria)
        {
            return _categoriaRepositorio.Remover(categoria);
        }
    }
}

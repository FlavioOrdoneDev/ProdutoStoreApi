using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppServicos
{
    public class CategoriaAppServico : ICategoriaAppServico
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaAppServico(ICategoriaServico categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        public CategoriaViewModel Adicionar(Categoria categoria)
        {
            var resultado = _categoriaServico.Adicionar(categoria);

            return new CategoriaViewModel(resultado);
        }

        public CategoriaViewModel Atualizar(Categoria categoria)
        {
            var resultado = _categoriaServico.Atualizar(categoria);

            return new CategoriaViewModel(resultado);
        }

        public CategoriaViewModel ObterPorId(int id)
        {
            var categoria = _categoriaServico.ObterPorId(id);
            return new CategoriaViewModel(categoria);
        }

        public IEnumerable<CategoriaViewModel> ObterTodas()
        {
            var categorias = _categoriaServico.ObterTodas();

            var categoriaViewModel = new List<CategoriaViewModel>();

            foreach (var categoria in categorias)
            {
                categoriaViewModel.Add(new CategoriaViewModel(categoria));
            }

            return categoriaViewModel;
        }

        public CategoriaViewModel Remover(Categoria categoria)
        {
            var resultado = _categoriaServico.Remover(categoria);
            return new CategoriaViewModel(resultado);
        }
    }
}

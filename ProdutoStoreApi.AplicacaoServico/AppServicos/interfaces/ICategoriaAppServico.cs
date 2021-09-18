using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppServicos
{
    public interface ICategoriaAppServico
    {
        CategoriaViewModel Adicionar(Categoria categoria);
        CategoriaViewModel Atualizar(Categoria categoria);
        CategoriaViewModel ObterPorId(int id);
        IEnumerable<CategoriaViewModel> ObterTodas();     
        CategoriaViewModel Remover(Categoria categoria);
    }
}
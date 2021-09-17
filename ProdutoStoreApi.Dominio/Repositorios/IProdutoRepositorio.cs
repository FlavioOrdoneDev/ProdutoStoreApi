using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Repositorios
{
    public interface IProdutoRepositorio
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        Produto Remover(Produto produto);
    }
}

using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Servicos.Interfaces
{
    public interface ICategoriaServico
    {
        Categoria Adicionar(Categoria categoria);
        Categoria Atualizar(Categoria categoria);
        Categoria ObterPorId(int id);
        IEnumerable<Categoria> ObterTodas();
        Categoria Remover(Categoria categoria);
    }
}

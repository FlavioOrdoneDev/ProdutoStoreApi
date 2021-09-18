using FluentValidation;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Validacoes
{
    public class ProdutoValidador : AbstractValidator<Produto>
    {
        public ProdutoValidador()
        {
            RuleFor(produto => produto.Nome).NotNull().WithMessage("O nome é obrigatório.");
            RuleFor(produto => produto.Nome).MinimumLength(3).WithMessage("O nome não pode ter menos de 3 caracteres.");
            RuleFor(produto => produto.Nome).MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres.");

            RuleFor(produto => produto.Descricao).NotNull().WithMessage("A descrição é obrigatória.");
            RuleFor(produto => produto.Descricao).MinimumLength(3).WithMessage("A descrição não pode ter menos de 3 caracteres.");
            RuleFor(produto => produto.Descricao).MaximumLength(250).WithMessage("A descrição não pode ter mais que 250 caracteres.");

            RuleFor(produto => produto.CategoriaId).NotEmpty().WithMessage("A categoria é obrigatória");
        }
    }
}
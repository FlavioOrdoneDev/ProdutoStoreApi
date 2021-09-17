using FluentValidation;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Validacoes
{
    public class CategoriaValidador : AbstractValidator<Categoria>
    {
        public CategoriaValidador()
        {
            RuleFor(categoria => categoria.Nome).NotNull().WithMessage("O nome é obrigatório.");
            RuleFor(categoria => categoria.Nome).MinimumLength(3).WithMessage("O nome não pode ter menos de 3 caracteres.");
            RuleFor(categoria => categoria.Nome).MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres.");

            RuleFor(categoria => categoria.Descricao).NotNull().WithMessage("A descrição é obrigatória.");
            RuleFor(categoria => categoria.Descricao).MinimumLength(3).WithMessage("A descrição não pode ter menos de 3 caracteres.");
            RuleFor(categoria => categoria.Descricao).MaximumLength(255).WithMessage("A descrição não pode ter mais que 250 caracteres.");
        }
    }
}
using FluentValidation;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            ValidateItems();
            ValidateQuantity();
            ValidateCode();
            ValidateTotalValue();
            ValidateRequestDate();
        }

        private void ValidateRequestDate()
        {
            RuleFor(x => x.RequestDate)
                .NotEmpty()
                .WithMessage("Data de pedido deve ser informado.");

            RuleFor(x => x.RequestDate)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Data de pedido não pode ser uma data futura.");
        }

        private void ValidateCode()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Campo 'Código' deve ser informado");

            RuleFor(x => x.Code)
                .Length(2, 50)
                .WithMessage("Campo 'Código' deve possuir no mínmo 02 eno máximo 50 caracteres.");
        }

        private void ValidateTotalValue()
        {
            RuleFor(x => x.TotalValue)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor total do pedido deve ser maior ou igual a zero.");
        }

        private void ValidateQuantity()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Campo 'Quantidade' deve ser informado.");

            RuleFor(x => x.Quantity)
                .Must(x => x > 0)
                .WithMessage("Campo 'Quantidade' deve possuir ao menos 01 item");
        }

        private void ValidateItems()
        {
            RuleFor(x => x.Items)
               .NotEmpty()
               .Must(x => x.Any())
               .WithMessage("Pedidos devem possuir ao menos um produto para serem gerados.");
        }
    }
}

using FluentValidation;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Validators
{
    public class ValidateOrderItem : AbstractValidator<OrderItem>
    {
        public ValidateOrderItem()
        {
            ValidatePrice();
            ValidateQuantity();
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

        private void ValidatePrice()
        {
            RuleFor(x => x.SubTotal)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor total do item não deve ser um valor negativo");
        }
    }
}

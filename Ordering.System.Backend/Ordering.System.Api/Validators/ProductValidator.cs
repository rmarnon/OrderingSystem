using FluentValidation;
using Ordering.System.Api.Models;

namespace Ordering.System.Api.Validators
{
    public class ProductValidator : AbstractValidator<ProductInputModel>
    {
        public ProductValidator()
        {
            ValidateDescription();
            ValidateRegistrationDate();
            ValidateValue();
            ValidateCode();
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

        private void ValidateValue()
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor do produto não deve ser um valor negativo");
        }

        private void ValidateRegistrationDate()
        {
            RuleFor(x => x.RegistrationDate)
                .NotEmpty()
                .WithMessage("Data de registro do produto deve ser informado");

            RuleFor(x => x.RegistrationDate)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Data de registro não pode ser uma data futura.");
        }

        private void ValidateDescription()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Campo 'Descrição' deve ser informado");

            RuleFor(x => x.Description)
                .Length(3, 100)
                .WithMessage("Campo 'Descrição' deve possuir no mínmo 03 eno máximo 100 caracteres.");
        }
    }
}

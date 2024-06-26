﻿using FluentValidation;
using Ordering.System.Api.Models;
using Ordering.System.Api.Validators.Rules;

namespace Ordering.System.Api.Validators
{
    public class SupplierValidator : AbstractValidator<SupplierInputModel>
    {
        public SupplierValidator()
        {
            ValidateUf();
            ValidateCnpj();
            ValidateName();
            ValidateSocialReason();
            ValidateEmail();
        }

        private void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Campo 'Email' deve ser informado");

            RuleFor(x => x.Email)
                .MaximumLength(50)
                .WithMessage("Campo 'Email' deve possuir no máximo 50 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido!");
        }

        private void ValidateSocialReason()
        {
            RuleFor(x => x.SocialReason)
                .NotEmpty()
                .WithMessage("Campo 'Razão Social' deve ser informado");

            RuleFor(x => x.SocialReason)
                .Length(3, 100)
                .WithMessage("Campo 'Razão Social' deve possuir no mínimo 03 e no máximo 100 caracteres.");
        }

        private void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Campo 'Nome' deve ser informado");

            RuleFor(x => x.Name)
                .Length(2, 100)
                .WithMessage("Campo 'Nome' deve possuir no mínmo 02 eno máximo 100 caracteres.");

            RuleFor(x => x.Name)
                .Must(WordsValidator.IsValidText)
                .When(x => !string.IsNullOrWhiteSpace(x.Name))
                .WithMessage("Campo 'Nome' aceita apenas letras e números.");
        }

        private void ValidateCnpj()
        {
            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .WithMessage("Campo 'CNPJ' deve ser informado");

            RuleFor(x => x.Cnpj)
                .Must(CnpjValidator.IsValidCnpj)
                .WithMessage("CNPJ Inválido!");
        }

        private void ValidateUf()
        {
            RuleFor(x => x.Uf)
               .NotEmpty()
               .WithMessage("UF deve ser informado.");

            RuleFor(x => x.Uf)
                .IsInEnum()
                .WithMessage("UF informado não é válido");
        }
    }
}

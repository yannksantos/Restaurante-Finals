using Domain.Models.Validations.Domain.Models.Validations;
using FluentValidation;

namespace Domain.Models.Validations
{
    public class EntregadorValidation : AbstractValidator<Entregador>
    {
        public EntregadorValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Matches(@"^\+[1-9]{1}[0-9]{3,14}$").WithMessage("O campo {PropertyName} precisa ser um número de telefone válido");

            RuleFor(e => e.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo do Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(e => CpfValidacao.Validar(e.CPF)).Equal(true);
        }
    }
}

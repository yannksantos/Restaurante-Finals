using Domain.Models.Validations.Domain.Models.Validations;
using FluentValidation;

namespace Domain.Models.Validations
{
    public class ClientesValidation : AbstractValidator<Clientes>
    {
        public ClientesValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Matches(@"^\+[1-9]{1}[0-9]{3,14}$").WithMessage("O campo {PropertyName} precisa ser um número de telefone válido");

            RuleFor(c => c.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo do Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(c => CpfValidacao.Validar(c.CPF)).Equal(true);
        }

    }
}

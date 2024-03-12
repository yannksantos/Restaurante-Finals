using FluentValidation;

namespace Domain.Models.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco> 
    {
        public EnderecoValidation()
        {
            RuleFor(e => e.Rua)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.NumeroCasa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O campo {PropertyName} precisa ser um CEP válido");
        }
    }
}

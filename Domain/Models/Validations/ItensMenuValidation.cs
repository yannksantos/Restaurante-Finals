using FluentValidation;

namespace Domain.Models.Validations
{
    public class ItensMenuValidation : AbstractValidator<ItensMenu>
    {
        public ItensMenuValidation()
        {
            RuleFor(i => i.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Preco)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que 0");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que 0");
        }
    }
}

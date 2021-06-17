using FluentValidation;
using Vortx.Application.ViewModels;

namespace Vortx.Application.Validators
{
    public class PriceValidator : AbstractValidator<PriceViewModel>
    {        
        public static string OriginNullErrorMsg => "O campo do DDD de origem é obrigatório.";
        public static string DestinationNullErrorMsg => "O campo do DDD de dentino é obrigatório.";
        public static string PriceMinuteNullErrorMsg => "O campo preço do minuto é obrigatório.";
        public static string LengthDddErrorMsg => "O campo deve possuir 3 caracteres.";        
        public static string PriceErrorMsg => "O campo preço deve possuir um valor maior do que zero.";

        public PriceValidator()
        {

            RuleFor(c => c.DddOrigin)
                .NotEmpty()
                .WithMessage(OriginNullErrorMsg)
                .Length(3, 3)
                .WithMessage(LengthDddErrorMsg);

            RuleFor(c => c.DddDestination)
                .NotEmpty()
                .WithMessage(DestinationNullErrorMsg)
                .Length(3, 3)
                .WithMessage(LengthDddErrorMsg);

            RuleFor(c => c.Minute)
                .NotNull()
                .WithMessage(PriceMinuteNullErrorMsg)
                .GreaterThan(0)
                .WithMessage(PriceErrorMsg);
        }

    }
}

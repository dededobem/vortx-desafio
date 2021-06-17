using FluentValidation;
using Vortx.Application.ViewModels;

namespace Vortx.Application.Validators
{
    public class PlanValidator : AbstractValidator<PlanViewModel>
    {
        public static string NameNullErrorMsg => "O campo nome é obrigatório.";
        public static string MinuteNullErrorMsg => "O campo tempo é obrigatório.";
        public static string MinuteErrorMsg => "O tempo do plano dever ser um valor inteiro maior do que zero.";        

        public PlanValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(NameNullErrorMsg);

            RuleFor(c => c.TimeMinutes)
                .NotEmpty()
                .WithMessage(MinuteNullErrorMsg)
                .GreaterThan(0)
                .WithMessage(MinuteErrorMsg);
        }
    }
}

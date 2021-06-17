using FluentValidation;
using Vortx.Application.Requests;
using Vortx.Domain.Interfaces;

namespace Vortx.Application.Validators
{
    public class CalculationValidator : AbstractValidator<RequestCalculation>
    {
        private readonly IPriceRepository _priceRepository;
        public static string DddOriginNullErrorMsg => "O campo DDD de Origem é obrigatório.";
        public static string DddDestinationNullErrorMsg => "O campo DDD de Destino é obrigatório.";
        public static string PlanErrorMsg => "O campo plano é obrigatório.";
        public static string MinuteNullErrorMsg => "O campo duração da chamada é obrigatório.";

        public CalculationValidator(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;

            RuleFor(c => c.DddOrigin)
                .NotEmpty()
                .WithMessage(DddOriginNullErrorMsg);

            RuleFor(c => c.DddDestination)
                .NotEmpty()
                .WithMessage(DddDestinationNullErrorMsg);

            RuleFor(c => c.CallTime)
                .NotEmpty()
                .WithMessage(MinuteNullErrorMsg);

        }
        
    }
}

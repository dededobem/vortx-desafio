using System;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;
using Vortx.Application.Interfaces;
using Vortx.Application.ViewModels;
using Vortx.Domain.Interfaces;

namespace Vortx.Application.Services
{
    public class AppCalculation : IAppCalculation
    {
        private readonly IPlanRepository _planRepository;
        private readonly IPriceRepository _priceRepository;

        public AppCalculation(IPlanRepository planRepository, 
            IPriceRepository priceRepository)
        {
            _planRepository = planRepository;
            _priceRepository = priceRepository;
        }

        public async Task<CalculationViewModel> CalculatePrice(string dddOrigin, string dddDestination, 
            int callTime, Guid planId)
        {
            if (!await VerifyExistsPrice(dddOrigin, dddDestination))
                throw new ApiException("Não existe preço cadastrado para a origem e o destino informados.");
            var price = await _priceRepository.GetPriceByOriginDestination(dddOrigin, dddDestination);
            var plan = await _planRepository.GetById(planId);
            return new CalculationViewModel(plan, price, callTime);
        }

        private async Task<bool> VerifyExistsPrice(string origin, string destination) =>
            await _priceRepository.VerifyExistsPriceRegistered(origin, destination);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vortx.Application.Exceptions;
using Vortx.Application.Interfaces;
using Vortx.Application.ViewModels;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces;

namespace Vortx.Application.Services
{
    public class AppPrice : IAppPrice
    {
        private readonly IPriceRepository _priceRepository;

        public AppPrice(IPriceRepository priceRepository) =>
            _priceRepository = priceRepository;

        public async Task<PriceViewModel> Add(PriceViewModel priceViewModel)
        {
            if (await ExistsPrice(priceViewModel.DddOrigin, priceViewModel.DddDestination))
                throw new ApiException("Já existe um preço cadastrado para os DDDs de origem e destino informados.");
            var price = new Price(
                    priceViewModel.Id,
                    priceViewModel.DddOrigin,
                    priceViewModel.DddDestination,
                    priceViewModel.Minute,
                    priceViewModel.CreatedAt,
                    priceViewModel.UpdatedAt);
            _priceRepository.Add(price);
            return new PriceViewModel(price);
        }

        public async Task<IEnumerable<PriceViewModel>> GetAll() =>
            (await _priceRepository.GetAll()).Select(x => new PriceViewModel(x));

        public async Task<PriceViewModel> GetById(Guid id) =>
            new PriceViewModel(await VerifyPrice(id));

        public Task<double> GetPriceByOriginDestination(string orgin, string destination)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id) =>
            _priceRepository.Delete(await VerifyPrice(id));

        public async Task<PriceViewModel> Update(Guid id, PriceViewModel priceViewModel)
        {
            var priceRepo = await VerifyPrice(id);
            var price = new Price(
                    priceRepo.Id,
                    priceViewModel.DddOrigin,
                    priceViewModel.DddDestination,
                    priceViewModel.Minute,
                    priceViewModel.CreatedAt,
                    priceViewModel.UpdatedAt);
            _priceRepository.Update(price);
            return new PriceViewModel(price);
        }

        public async Task<Price> VerifyPrice(Guid id)
        {
            var price = await _priceRepository.GetById(id);
            if (price == null)
                throw new ApiException("Preço de origens e destinos não encontrado!");
            return price;
        }

        public async Task<bool> ExistsPrice(string dddOrigin, string dddDestination) =>
            await _priceRepository.VerifyExistsPriceRegistered(dddOrigin, dddDestination);
    }
}

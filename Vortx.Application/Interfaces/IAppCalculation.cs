using System;
using System.Threading.Tasks;
using Vortx.Application.ViewModels;

namespace Vortx.Application.Interfaces
{
    public interface IAppCalculation
    {
        Task<CalculationViewModel> CalculatePrice(string dddOrigin, string dddDestination,
            int callTime, Guid planId);
    }
}

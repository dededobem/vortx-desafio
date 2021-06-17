using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vortx.Application.Interfaces;
using Vortx.Application.Requests;

namespace Vortx.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculationController : Controller
    {
        private readonly IAppCalculation _appCalculation;

        public CalculationController(IAppCalculation appCalculation) =>
            _appCalculation = appCalculation;

        /// <summary>
        /// Calcular preços das ligações com plano e sem plano
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CalculatePrice(RequestCalculation request) =>
            Ok(await _appCalculation.CalculatePrice(
                request.DddOrigin,
                request.DddDestination,
                request.CallTime,
                request.PlanId)
              );

    }
}

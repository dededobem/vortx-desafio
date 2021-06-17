using Vortx.Domain.Entities;

namespace Vortx.Application.ViewModels
{
    public class CalculationViewModel
    {
        public CalculationViewModel(Plan plan, Price price, int callTime)
        {
            PriceWithPlan = plan.CalculateCall(price.Minute, callTime);
            PriceWithoutPlan = price.CalculateCall(callTime);
        }

        public double PriceWithPlan { get; private set; }
        public double PriceWithoutPlan { get; private set; }
    }
}

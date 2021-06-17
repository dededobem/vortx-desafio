using System;
using Vortx.Domain.Entities;

namespace Vortx.Application.ViewModels
{
    public class PriceViewModel
    {
        public PriceViewModel() { }
        public PriceViewModel(Price price)
        {
            Id = price.Id;
            DddOrigin = price.DddOrigin;
            DddDestination = price.DddDestination;
            Minute = price.Minute;
            CreatedAt = price.CreatedAt;
            UpdatedAt = price.UpdatedAt;
        }

        public Guid Id { get; private set; }        
        public string DddOrigin { get; set; }        
        public string DddDestination { get; set; }        
        public double Minute { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}

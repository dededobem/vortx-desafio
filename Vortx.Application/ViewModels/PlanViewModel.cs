using System;
using Vortx.Domain.Entities;

namespace Vortx.Application.ViewModels
{
    public class PlanViewModel
    {
        public PlanViewModel() { }
        public PlanViewModel(Plan plan)
        {
            Id = plan.Id;
            Name = plan.Name;
            TimeMinutes = plan.TimeMinutes;
            CreatedAt = plan.CreatedAt;
            UpdatedAt = plan.UpdatedAt;
        }

        public Guid Id { get; private set; }        
        public string Name { get; set; }        
        public int TimeMinutes { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}

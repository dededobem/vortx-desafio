using System;
using System.ComponentModel.DataAnnotations;

namespace Vortx.Application.Requests
{
    public class RequestCalculation
    {
        public string DddOrigin { get; set; }
        public string DddDestination { get; set; }
        public int CallTime { get; set; }
        public Guid PlanId { get; set; }
    }
}

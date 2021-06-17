using System;

namespace Vortx.Domain.Entities
{
    public class Plan : EntityBase
    {
        public Plan(Guid id, string name, int timeMinutes, 
            DateTime createdAt, DateTime? updatedAt) : base(id, createdAt, updatedAt)
        {
            Name = name;
            TimeMinutes = timeMinutes;
        }

        protected Plan() { }

        public string Name { get; private set; }
        public int TimeMinutes { get; private set; }

        public double CalculateCall(double minute, int callTime) =>
            TimeMinutes > callTime ? 0 : (callTime - TimeMinutes) * (minute + (minute * 0.1));

    }    

}

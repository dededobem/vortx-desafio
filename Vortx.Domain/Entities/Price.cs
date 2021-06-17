using System;

namespace Vortx.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(Guid id, string dddOrigin, string dddDestination, 
            double minute, DateTime createdAt, DateTime? updatedAt) : 
            base(id, createdAt, updatedAt)
        {
            DddOrigin = dddOrigin;
            DddDestination = dddDestination;
            Minute = minute;
        }        
        protected Price() { }

        public string DddOrigin { get; private set; }
        public string DddDestination { get; private set; }
        public double Minute { get; private set; }

        public double CalculateCall(int callTime) =>
            callTime * Minute;
    }
}

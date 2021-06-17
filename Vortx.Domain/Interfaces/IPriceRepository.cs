using System.Threading.Tasks;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces.Base;

namespace Vortx.Domain.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Price> GetPriceByOriginDestination(string orgin, string destination);
        Task<bool> VerifyExistsPriceRegistered(string origin, string destination);
    }
}

using System.Threading.Tasks;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces.Base;

namespace Vortx.Domain.Interfaces
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<bool> VerifyExists(string name); 
    }
}

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces;
using Vortx.Infrastructure.Data;
using Vortx.Infrastructure.Repositories.Base;

namespace Vortx.Infrastructure.Repositories
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {        
        private readonly DbSet<Plan> _dbSet;

        public PlanRepository(VortxContext context) : base(context) =>
            _dbSet = context.Set<Plan>();

        public async Task<bool> VerifyExists(string name) => 
            await _dbSet.AnyAsync(x => x.Name == name);
    }
}

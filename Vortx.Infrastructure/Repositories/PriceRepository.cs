using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vortx.Domain.Entities;
using Vortx.Domain.Interfaces;
using Vortx.Infrastructure.Data;
using Vortx.Infrastructure.Repositories.Base;

namespace Vortx.Infrastructure.Repositories
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {        
        private readonly DbSet<Price> _dbSet;

        public PriceRepository(VortxContext context) : base(context)
        {            
            _dbSet = context.Set<Price>();
        }            

        public async Task<Price> GetPriceByOriginDestination(string orgin, string destination) =>
            await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DddOrigin == orgin && x.DddDestination == destination);

        public async Task<bool> VerifyExistsPriceRegistered(string origin, string destination) =>
            await _dbSet.AnyAsync(x => x.DddOrigin == origin && x.DddDestination == destination);        

    }
}

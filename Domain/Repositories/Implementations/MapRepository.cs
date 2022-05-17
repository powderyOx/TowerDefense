using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class MapRepository : ARepository<GameMap>, IMapRepository
{
    public MapRepository(TowerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<GameMap?> ReadGraphAsync(int id)
        => await _table
            .Where(map => map.MapId == id)
            .Include(m => m.Fields)
            .SingleOrDefaultAsync();
}
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SavedGameRepository : ARepository<SavedGame>, ISavedGameRepository
{
    public SavedGameRepository(TowerDbContext dbContext) : base(dbContext) { }

    public async Task<SavedGame?> ReadGraphAsync(int id)
        => await _table
            .Where(s => s.SavedGameId == id)
            .Include(s => s.SavedGameId)
            .SingleOrDefaultAsync();
}
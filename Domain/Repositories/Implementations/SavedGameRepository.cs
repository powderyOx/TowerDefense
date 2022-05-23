using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SavedGameRepository : ARepository<SavedGame>, ISavedGameRepository
{
    public SavedGameRepository(TowerDbContext dbContext) : base(dbContext) { }

    public async Task<SavedGame> ReadGraphAsync(int id)
        => await _table
            .Include(m => m.MapEntities) // List aus JT
            .ThenInclude(m=>m.AEntity)
            .SingleOrDefaultAsync(s => s.SavedGameId == id);
}
﻿using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SavedGameRepository : ARepository<SavedGame>, ISavedGameRepository
{
    public SavedGameRepository(TowerDbContext dbContext) : base(dbContext) { }
    /*
    public async Task<List<SavedGame>> ReadGraphAsync(Expression<Func<SavedGame, bool>> filter)
        => await _table
            .Include(a => a.MapEntities)
            .Where(filter)
            .ToListAsync();
    
     */

    public async Task<List<SavedGame>?> ReadGraphAsync(Expression<Func<SavedGame, bool>> filter)
        => await _table
            .Include(m => m.MapEntities)
            .ThenInclude(m => m.Entity)
            .Where(filter)
            .ToListAsync();
}
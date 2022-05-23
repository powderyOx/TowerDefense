using System.Linq.Expressions;
using Model.Entities;

namespace Domain.Repositories.Interfaces; 

public interface ISavedGameRepository : IRepository<SavedGame> {
    Task<List<SavedGame>?> ReadGraphAsync(Expression<Func<SavedGame, bool>> filter);
}
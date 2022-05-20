using System.Linq.Expressions;
using Model.Entities;

namespace Domain.Repositories.Interfaces; 

public interface ISavedGameRepository : IRepository<SavedGame> {
    Task<SavedGame?> ReadGraphAsync(int id);
}
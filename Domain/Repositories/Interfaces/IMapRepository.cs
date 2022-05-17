using System.Linq.Expressions;
using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IMapRepository : IRepository<GameMap>
{
    Task<GameMap?> ReadGraphAsync(int id);
}
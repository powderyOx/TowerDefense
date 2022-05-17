using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations; 

public class GameRepository : ARepository<SavedGame> {
    public GameRepository(TowerDbContext dbContext) : base(dbContext) {
    }
}
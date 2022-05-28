using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 
[Table("MAP_HAS_ENTITIES_JT")]
public abstract class  MapEntity {
  
    [Column("ENTITY_ID")]
    public int EntityId { get; set; }

    public AEntity AEntity { get; set; }

    [Column("SAVED_GAME_ID")]
    public int SavedGameId { get; set; }

    public SavedGame SavedGame { get; set; }
    
    [Column("X")]
    public int? X { get; set; }
    
    [Column("Y")]
    public int? Y { get; set; }
    
    public abstract string GetEntityType();
}
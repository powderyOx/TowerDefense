using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Map;

namespace Model.Entities; 

[Table("MAPS")]
public class GameMap{
    [Column("MAP_ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MapId { get; set; }
    
    public List<AField> Fields { get; set; } = new();

}
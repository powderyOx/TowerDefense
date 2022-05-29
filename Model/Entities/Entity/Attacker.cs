using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 
[Table(("ATTACKERS"))]
public class Attacker : AEntity {
    [Column("SPEED")]
    [Required]
    public int Speed { get; set; }
    
    [Column("HP")] 
    [Required]
    public int Hp { get; set; }
    
    [Column("SHIELD")]
    [Required]
    public int Shield { get; set; }
    
    [Column("LOOT")]
    [Required]
    public int Loot { get; set; }

    [Column("ROUND_ID")]
    [Required]
    public int RoundId { get; set; }

    public Round Round { get; set; }
    public override string GetEntityType() {
        return "./image/attackers/" + EntityType + ".png";
    }
}

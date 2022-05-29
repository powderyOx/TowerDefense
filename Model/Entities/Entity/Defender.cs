using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("DEFENDERS")]
public class Defender : AEntity {
    [Column("FIRE_RATE")]
    [Required]
    public int FireRate { get; set; }

    [Column("RANGE")]
    [Required]
    public int Range { get; set; }

    [Column("COST")]
    [Required]
    public int Cost { get; set; }

    [Column("ROUND")]
    [Required]
    public int Round { get; set; }
    
    public override string GetEntityType() {
        return "./image/defenders/" + EntityType + ".png";
    }
    
}
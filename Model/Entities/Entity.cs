using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("ENTITIES_BT")]
public abstract class Entity {
    [Column("ENTITY_ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EntityId { get; set; }
    
    [Column("DAMAGE")]
    [Required]
    public int Damage { get; set; }
    
    [Column("ENTITY_TYPE")]
    [Required, StringLength(45)]
    public string EntityType { get; set; }

    [Column("NAME")]
    [Required, StringLength(45)]
    public string Name { get; set; }
}
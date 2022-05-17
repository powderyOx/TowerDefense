using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Map;

[Table("FIELDS_ST")]
public abstract class AField
{
    [Column("X")]
    public int X { get; set; }

    [Column("Y")]
    public int Y { get; set; }

    [Column("MAP_ID")]
    [Required]
    public int MapId { get; set; }
    public GameMap Map { get; set; }

    public abstract string GetFieldType();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("SAVED_GAMES")]
public class SavedGame {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SAVED_GAME_ID")] 
    public int SavedGameId { get; set; }

    [Column("MONEY")]
    [Required]
    public int Money { get; set; }

    [Column("ROUND")]
    [Required]
    public int Round { get; set; }

    [Column("NAME")]
    [Required, StringLength(45)]
    public string Name { get; set; }

    [Column("HP")]
    [Required]
    public int HP { get; set; }
}
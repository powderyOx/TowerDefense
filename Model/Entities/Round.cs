using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("ROUNDS")]
public class Round {
    [Column("ROUND_ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoundId { get; set; }
}
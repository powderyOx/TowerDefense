using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Map;
using Model.Entities.Map.FieldTypes;

namespace Model.Entities; 

[Table("MAPS")]
public class GameMap{
    [Column("MAP_ID")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MapId { get; set; }
    
    public List<AField> Fields { get; set; } = new();

    public List<AField> GetPath() {
        var path = new List<AField?>();
        var fieldList = new FieldList(Fields);

        var firstField = fieldList.SingleOrDefault(f => f.Y == 0 && f is not EmptyField);
        
        var currentField = firstField;
        
        // leida nd rekursiv
        while (fieldList.GetNextField(currentField, path.LastOrDefault()) != null) {
            var previousField = path.LastOrDefault();
            path.Add(currentField);
            currentField = fieldList.GetNextField(currentField, previousField);
        }
        path.Add(currentField);
        return path;
    }
}
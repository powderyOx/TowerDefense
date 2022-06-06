using Model.Entities.Map.FieldTypes;

namespace Model.Entities.Map;

public class FieldList : List<AField>
{
    public AField? GetField(int x, int y)
        => this.SingleOrDefault(f => f.X == x && f.Y == y);

    public FieldList(IEnumerable<AField> collection) : base(collection)
    {
    }

    public int GetMaxX()
        => this.Max(f => f.X);

    public int GetMinY()
        => this.Max(f => f.Y);

    public bool Contains(int x, int y)
        => this.Where(f => f.X == x && f.Y == y).Select(f => f).Count() == 1;

    public List<AField> GetNeighborFields(AField field) {
        var list = new List<AField>();
        list.Add(this.SingleOrDefault(f=>f.X == field.X-1 && f.Y == field.Y));
        list.Add(this.SingleOrDefault(f=>f.X == field.X+1 && f.Y == field.Y));
        list.Add(this.SingleOrDefault(f=>f.X == field.X && f.Y == field.Y-1));
        list.Add(this.SingleOrDefault(f=>f.X == field.X && f.Y == field.Y+1));
        list.RemoveAll(le => le == null);
        return list;
    }

    public List<AField> GetNeighborPathFields(AField field) =>GetNeighborFields(field).Where(f=>f is not EmptyField).ToList();

    public AField GetNextField(AField field, AField? previousField) => GetNeighborPathFields(field).SingleOrDefault(f=> f != previousField);
    
}
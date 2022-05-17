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
    
    
}
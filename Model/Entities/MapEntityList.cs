namespace Model.Entities; 

public class MapEntityList : List<MapEntity> {
    public MapEntity? GetMapEntity(int x, int y)
        => this.SingleOrDefault(me => me.X == x && me.Y == y);
    public MapEntityList(IEnumerable<MapEntity> collection) : base(collection) { }
}
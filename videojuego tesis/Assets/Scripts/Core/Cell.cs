public class Cell
{
    public Position Position { get; }

    public GroundType Ground { get; private set; }
    public ObjectType Object { get; private set; }
    public EntityType Entity { get; private set; }

    public Cell(Position position)
    {
        Position = position;
        Ground = GroundType.Floor;
        Object = ObjectType.None;
        Entity = EntityType.None;
    }

    public Cell Clone()
    {
        Cell clone = new Cell(Position);

        clone.SetGround(Ground);
        clone.SetObject(Object);
        clone.SetEntity(Entity);

        return clone;
    }

    public void SetGround(GroundType ground)
    {
        Ground = ground;
    }

    public void SetObject(ObjectType obj)
    {
        Object = obj;
    }

    public void SetEntity(EntityType entity)
    {
        Entity = entity;
    }

    public void ClearObject()
    {
        Object = ObjectType.None;
    }

    public void ClearEntity()
    {
        Entity = EntityType.None;
    }
    public bool HasObject()
    {
        return Object != ObjectType.None;
    }

    public bool HasEntity()
    {
        return Entity != EntityType.None;
    }

    public bool IsWall()
    {
        return Ground == GroundType.Wall;
    }

    public bool IsWalkable()
    {
        return Ground != GroundType.Wall;
    }

}
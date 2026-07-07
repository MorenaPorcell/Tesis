public static class CellFactory
{
    public static void ConfigureCell(Cell cell, char symbol)
    {
        cell.SetGround(GroundType.Floor);
        cell.ClearObject();
        cell.ClearEntity();

        switch (symbol)
        {
            case LevelSymbols.Wall:
                cell.SetGround(GroundType.Wall);
                break;

            case LevelSymbols.Player:
                cell.SetEntity(EntityType.Player);
                break;

            case LevelSymbols.Key:
                cell.SetObject(ObjectType.Key);
                break;

            case LevelSymbols.Door:
                cell.SetObject(ObjectType.Door);
                break;

            case LevelSymbols.Goal:
                cell.SetObject(ObjectType.Goal);
                break;
        }
    }
}
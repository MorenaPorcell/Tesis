using System.Collections.Generic;

public static class DirectionUtility
{
    public static readonly Direction[] CardinalDirections =
    {
        Direction.Up,
        Direction.Down,
        Direction.Left,
        Direction.Right
    };

    public static readonly Dictionary<Direction, Position> Offsets =
    new()
    {
        { Direction.Up,    new Position(0, 1) },
        { Direction.Down,  new Position(0,-1) },
        { Direction.Left,  new Position(-1,0) },
        { Direction.Right, new Position(1,0) }
    };
}
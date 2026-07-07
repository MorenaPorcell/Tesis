using UnityEngine;

public static class GridUtility
{
    public const float CellSize = 1f;

    public static Vector3 GridToWorld(Position position)
    {
        return new Vector3(
            position.X * CellSize,
            position.Y * CellSize,
            0f);
    }
}
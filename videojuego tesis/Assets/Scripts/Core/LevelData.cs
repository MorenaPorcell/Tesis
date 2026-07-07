using System.Collections.Generic;

public class LevelData
{
    private readonly Cell[,] cells;

    public int Width { get; }
    public int Height { get; }

    public LevelData(int width, int height)
    {
        Width = width;
        Height = height;

        cells = new Cell[width, height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                cells[x, y] = new Cell(new Position(x, y));
            }
        }
    }

    public bool IsInsideGrid(Position position)
    {
        return position.X >= 0 &&
               position.X < Width &&
               position.Y >= 0 &&
               position.Y < Height;
    }

    public Cell GetCell(Position position)
    {
        if (!IsInsideGrid(position))
            return null;

        return cells[position.X, position.Y];
    }

    public void SetCell(Cell cell)
    {
        if (!IsInsideGrid(cell.Position))
            return;

        cells[cell.Position.X, cell.Position.Y] = cell;
    }

    public LevelData Clone()
    {
        LevelData clone = new LevelData(Width, Height);

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                clone.cells[x, y] = cells[x, y].Clone();
            }
        }

        return clone;
    }

    public Cell GetNeighbor(Cell cell, Direction direction)
    {
        Position offset = DirectionUtility.Offsets[direction];

        Position neighborPosition = new Position(
            cell.Position.X + offset.X,
            cell.Position.Y + offset.Y);

        return GetCell(neighborPosition);
    }

    public IEnumerable<Cell> GetNeighbors(Cell cell)
    {
        foreach (Direction direction in DirectionUtility.CardinalDirections)
        {
            Cell neighbor = GetNeighbor(cell, direction);

            if (neighbor != null)
                yield return neighbor;
        }
    }
}
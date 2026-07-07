using UnityEngine;

public static class LevelParser
{
    public static LevelData Parse(string[] map)
    {
        int height = map.Length;
        int width = map[0].Length;

        LevelData level = new LevelData(width, height);

        for (int y = 0; y < height; y++)
        {
            string row = map[y];

            for (int x = 0; x < width; x++)
            {
                Cell cell = level.GetCell(new Position(x, y));

                CellFactory.ConfigureCell(cell, row[x]);
            }
        }

        return level;
    }
}
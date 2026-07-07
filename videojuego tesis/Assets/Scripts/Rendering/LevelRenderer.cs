using UnityEngine;

public class LevelRenderer : MonoBehaviour
{
    [Header("Parents")]
    [SerializeField] private Transform levelParent;

    [Header("Prefab Database")]
    [SerializeField]
    private PrefabDatabase prefabDatabase;

    private CellView[,] cellViews;

    private void Start()
    {
        Render(GridManager.Instance.CurrentLevel);
    }

    public void Render(LevelData level)
    {
        cellViews = new CellView[level.Width, level.Height];

        if (level == null)
        {
            UnityEngine.Debug.LogWarning("No hay un nivel para renderizar.");
            return;
        }

        Clear();

        for (int x = 0; x < level.Width; x++)
        {
            for (int y = 0; y < level.Height; y++)
            {
                Position position = new Position(x, y);

                Cell cell = level.GetCell(position);

                cellViews[x, y] = new CellView(position);

                DrawGround(cell);

                DrawObject(cell);

                DrawEntity(cell);
            }
        }
    }

    private void DrawGround(Cell cell)
    {
        GameObject prefab = prefabDatabase.GetGroundPrefab(cell.Ground);

        GameObject instance = SpawnPrefab(prefab, cell.Position);

        cellViews[cell.Position.X, cell.Position.Y]
            .SetGround(instance);
    }

    private void DrawObject(Cell cell)
    {
        GameObject prefab = prefabDatabase.GetObjectPrefab(cell.Object);

        GameObject instance = SpawnPrefab(prefab, cell.Position);

        cellViews[cell.Position.X, cell.Position.Y]
            .SetObject(instance);
    }

    private void DrawEntity(Cell cell)
    {
        GameObject prefab = prefabDatabase.GetEntityPrefab(cell.Entity);

        GameObject instance = SpawnPrefab(prefab, cell.Position);

        cellViews[cell.Position.X, cell.Position.Y]
            .SetEntity(instance);
    }

    private GameObject SpawnPrefab(GameObject prefab, Position position)
    {
        if (prefab == null)
            return null;

        return Instantiate(
            prefab,
            GridUtility.GridToWorld(position),
            Quaternion.identity,
            levelParent);
    }

    public CellView GetCellView(Position position)
    {
        if (cellViews == null)
            return null;

        if (position.X < 0 || position.X >= cellViews.GetLength(0))
            return null;

        if (position.Y < 0 || position.Y >= cellViews.GetLength(1))
            return null;

        return cellViews[position.X, position.Y];
    }

    private void Clear()
    {
        for (int i = levelParent.childCount - 1; i >= 0; i--)
        {
            Destroy(levelParent.GetChild(i).gameObject);
        }
    }
}
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;

    private LevelData currentLevel;

    public LevelData CurrentLevel => currentLevel;

    public int Width => width;
    public int Height => height;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        CreateEmptyLevel();
    }

    // Crea un nuevo tablero vacío.
    private void CreateGrid()
    {
        currentLevel = new LevelData(width, height);

        UnityEngine.Debug.Log($"Grid creado correctamente. Tamaño: {width}x{height}");
    }

    // Elimina el tablero actual.
    public void CreateEmptyLevel()
    {
        currentLevel = new LevelData(width, height);
    }

    // Carga un nuevo nivel.
    public void LoadLevel(LevelData level)
    {
        currentLevel = level;
    }

    // Devuelve la celda indicada.
    public Cell GetCell(Position position)
    {
        return GetCell(position.X, position.Y);
    }

    public Cell GetCell(int x, int y)
    {
        if (currentLevel == null)
            return null;

        return currentLevel.GetCell(new Position(x, y));
    }

    // Comprueba si una posición pertenece al tablero.
    public bool IsInsideGrid(Position position)
    {
        return IsInsideGrid(position.X, position.Y);
    }

    public bool IsInsideGrid(int x, int y)
    {
        return x >= 0 &&
               x < width &&
               y >= 0 &&
               y < height;
    }

    // Comprueba si una celda puede ser atravesada.
    public bool IsWalkable(Position position)
    {
        Cell cell = GetCell(position);

        if (cell == null)
            return false;

        return cell.Ground != GroundType.Wall;
    }

    public void SetGround(Position position, GroundType ground)
    {
        Cell cell = GetCell(position);

        if (cell == null)
            return;

        cell.SetGround(ground);
    }

    public void SetObject(Position position, ObjectType obj)
    {
        Cell cell = GetCell(position);

        if (cell == null)
            return;

        cell.SetObject(obj);
    }

    public void SetEntity(Position position, EntityType entity)
    {
        Cell cell = GetCell(position);

        if (cell == null)
            return;

        cell.SetEntity(entity);
    }
}
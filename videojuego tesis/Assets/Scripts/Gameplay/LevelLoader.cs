using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelRenderer levelRenderer;

    private readonly string[] level =
    {
        "##########",
        "#P.......#",
        "#..K.....#",
        "#........#",
        "#..###...#",
        "#.....D..#",
        "#........#",
        "#........#",
        "#.......G#",
        "##########"
    };

    private void Start()
    {
        LevelData levelData = LevelParser.Parse(level);

        GridManager.Instance.LoadLevel(levelData);

        levelRenderer.Render(levelData);
    }
}
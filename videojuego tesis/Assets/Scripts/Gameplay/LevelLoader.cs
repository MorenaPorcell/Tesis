using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelRenderer levelRenderer;

    private readonly string[] level =
    {
        "##########",
        "#P......P#",
        "#..K.....#",
        "#........#",
        "#..###...#",
        "#.....D..#",
        "#........#",
        "#..K.....#",
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
using UnityEngine;

public class CellView
{
    public Position Position { get; }

    public GameObject GroundObject { get; private set; }

    public GameObject ObjectObject { get; private set; }

    public GameObject EntityObject { get; private set; }

    public CellView(Position position)
    {
        Position = position;
    }

    public void SetGround(GameObject obj)
    {
        GroundObject = obj;
    }

    public void SetObject(GameObject obj)
    {
        ObjectObject = obj;
    }

    public void SetEntity(GameObject obj)
    {
        EntityObject = obj;
    }
}
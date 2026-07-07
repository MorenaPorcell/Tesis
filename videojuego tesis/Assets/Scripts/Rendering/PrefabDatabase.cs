using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GroundPrefabEntry
{
    public GroundType Type;
    public GameObject Prefab;
}

[Serializable]
public class ObjectPrefabEntry
{
    public ObjectType Type;
    public GameObject Prefab;
}

[Serializable]
public class EntityPrefabEntry
{
    public EntityType Type;
    public GameObject Prefab;
}

[CreateAssetMenu(
    fileName = "PrefabDatabase",
    menuName = "Puzzle Game/Prefab Database")]
public class PrefabDatabase : ScriptableObject
{
    [Header("Ground")]
    [SerializeField] private List<GroundPrefabEntry> groundPrefabs = new();

    [Header("Objects")]
    [SerializeField] private List<ObjectPrefabEntry> objectPrefabs = new();

    [Header("Entities")]
    [SerializeField] private List<EntityPrefabEntry> entityPrefabs = new();

    private Dictionary<GroundType, GameObject> groundDictionary;
    private Dictionary<ObjectType, GameObject> objectDictionary;
    private Dictionary<EntityType, GameObject> entityDictionary;

    private void Initialize()
    {
        if (groundDictionary != null &&
            objectDictionary != null &&
            entityDictionary != null)
        {
            return;
        }

        groundDictionary = new Dictionary<GroundType, GameObject>();
        objectDictionary = new Dictionary<ObjectType, GameObject>();
        entityDictionary = new Dictionary<EntityType, GameObject>();

        foreach (GroundPrefabEntry entry in groundPrefabs)
        {
            if (!groundDictionary.ContainsKey(entry.Type))
                groundDictionary.Add(entry.Type, entry.Prefab);
        }

        foreach (ObjectPrefabEntry entry in objectPrefabs)
        {
            if (!objectDictionary.ContainsKey(entry.Type))
                objectDictionary.Add(entry.Type, entry.Prefab);
        }

        foreach (EntityPrefabEntry entry in entityPrefabs)
        {
            if (!entityDictionary.ContainsKey(entry.Type))
                entityDictionary.Add(entry.Type, entry.Prefab);
        }
    }

    public GameObject GetGroundPrefab(GroundType type)
    {
        Initialize();

        groundDictionary.TryGetValue(type, out GameObject prefab);

        return prefab;
    }

    public GameObject GetObjectPrefab(ObjectType type)
    {
        Initialize();

        objectDictionary.TryGetValue(type, out GameObject prefab);

        return prefab;
    }

    public GameObject GetEntityPrefab(EntityType type)
    {
        Initialize();

        entityDictionary.TryGetValue(type, out GameObject prefab);

        return prefab;
    }
}
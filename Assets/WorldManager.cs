using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldLevelEntry
{
    public int levelID;
    public GameObject LevelPrefab;
}

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    [SerializeField]
    public List<WorldLevelEntry> worldDictionary;
    Dictionary<int, GameObject> worldRegistry = new Dictionary<int, GameObject>();

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else if (Instance != this) { Destroy(gameObject); }

        foreach (var entry in worldDictionary)
        {
            worldRegistry.Add(entry.levelID, entry.LevelPrefab);
        }

        SpawnLevel(0);
    }

    public void SpawnLevel(int levelID)
    {
        Instantiate(GetWorldByID(levelID), this.transform);
    }

    public GameObject GetWorldByID(int id)
    {
        if (worldRegistry.TryGetValue(id, out GameObject levelPrefab))
        {
            return levelPrefab;
        }

        return null; // or handle the case where the species is not found
    }
}
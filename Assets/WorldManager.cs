using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Definition for what data pairing should qualify as an entry in 
//our world dictionary/registry which will allow specific lookup
[System.Serializable]
public class WorldLevelEntry
{
    public int levelID; //Each level should have an ID for lookup
    public GameObject LevelPrefab; //and a corresponding prefab
}

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance; //Global instance
    public int CurrentLevel; //Currently loaded world LevelID
    public bool LevelLoaded = false; //Whether or not a level is loaded

    [SerializeField]
    public List<WorldLevelEntry> worldDictionary; //Dictionary for holding values
    Dictionary<int, GameObject> worldRegistry = new Dictionary<int, GameObject>();    
    public List<GameObject> battlefieldRegistry; //Registry for battlefield pairing

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else if (Instance != this) { Destroy(gameObject); }

        //Setup the world registry with key/value pairing
        foreach (var entry in worldDictionary)
            worldRegistry.Add(entry.levelID, entry.LevelPrefab);
        
        //Spawn the debug level
        SpawnLevel(0);
    }

    //Method to spawn a level based on a levelID provided
    public void SpawnLevel(int levelID)
    {
        ClearLevel(); //Clear the previously loaded level
        Instantiate(GetWorldByID(levelID), this.transform); //Load the new level
        CurrentLevel = levelID;
        LevelLoaded = true; //Update bool accordingly
    }

    //Method to clear the level (children) of this script
    public void ClearLevel()
    {
        //If there are children of this object, destroy them all
        if(this.transform.childCount > 0)
            foreach(Transform child in this.transform)
                Destroy(child.gameObject);

        LevelLoaded = false;//Update bool accordingly
    }

    //Method to spawn a battleground according to the level that was active
    public void SpawnBattleground(int worldID)
    {
        ClearLevel(); //Clear the previously loaded level
        //Load corresponding battlefield based on the ID of the level that was previously loaded
        Instantiate(battlefieldRegistry[worldID], this.transform); 
        LevelLoaded = true; //Update bool accordingly
    }

    //Method to return the prefab of a world based on the ID provided
    public GameObject GetWorldByID(int id)
    {
        //Check to see if the id/prefab pairing exists, and return value if it does
        if (worldRegistry.TryGetValue(id, out GameObject levelPrefab))
            return levelPrefab;

        return null; // or handle the case where the species is not found
    }
}
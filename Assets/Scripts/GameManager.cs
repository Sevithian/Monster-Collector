using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public class MonsterSpeciesEntry
{
    public int speciesID;
    public MonsterSpecies species;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    public List<MonsterSpeciesEntry> speciesDictionary;
    Dictionary<int, MonsterSpecies> speciesRegistry = new Dictionary<int, MonsterSpecies>();

    public PartyData PlayerParty;
    public WorldState SavedWorldData;

    void Awake()
    {
        foreach (var entry in speciesDictionary)
        {
            speciesRegistry.Add(entry.speciesID, entry.species);
        }

        PlayerParty = GetComponent<PartyData>();
        // Singleton pattern
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else if (Instance != this) { Destroy(gameObject); }
        AddDebugMonsters();
    }

    private void AddDebugMonsters()
    {
        var debugMon1 = new MonsterData (1)
        {
            Name = "George",
            Level = 15
        };
        var debugMon2 = new MonsterData (2)
        {
            Name = "Frank",
            Level = 15
        };
        debugMon1.CurrentStats = debugMon1.CalculateStats(debugMon1.Species, debugMon1.Level);
        debugMon1.FullHeal();
        debugMon2.CurrentStats = debugMon2.CalculateStats(debugMon2.Species, debugMon2.Level);
        debugMon2.FullHeal();
        PlayerParty.PrimaryMonster = debugMon1;
        PlayerParty.AddMonster(debugMon2);
    }

    public void SaveWorldState()
    {
        SavedWorldData = new WorldState();
        SavedWorldData.WorldID = WorldManager.Instance.CurrentLevel;
        SavedWorldData.PlayerPos = FindObjectOfType<PlayerController>().transform.position;
        Debug.Log("Saving world state");
    }

    public MonsterSpecies GetSpeciesByID(int id)
    {
        if (speciesRegistry.TryGetValue(id, out MonsterSpecies species))
        {
            return species;
        }
        return null; // or handle the case where the species is not found
    }

    public void FindPartyData()
    {
        PlayerParty = FindObjectOfType<PartyData>();
    }

    public void Update()
    {
        DebugInputs();
    }

    private void DebugInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Before swap: Primary - " + PlayerParty.PrimaryMonster.Name + ", Storage - " + PlayerParty.StorageMonsters[0].Name);
            // Existing swap logic...

            PlayerParty.SwapMonsters(PlayerParty.PrimaryMonster, PlayerParty.StorageMonsters[0]);
            Debug.Log("After swap: Primary - " + PlayerParty.PrimaryMonster.Name + ", Storage - " + PlayerParty.StorageMonsters[0].Name);
        }
    }

    public void SaveGame()
    {
        // Serialize PartyMonsters and StorageMonsters
    }

    public void LoadGame()
    {
        // Deserialize and set PartyMonsters and StorageMonsters
    }
}

public class WorldState
{
    public Vector3 PlayerPos;
    public int WorldID;
}


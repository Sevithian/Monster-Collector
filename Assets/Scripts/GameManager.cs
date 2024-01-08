using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PartyData PlayerParty;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else if (Instance != this) { Destroy(gameObject); }
    }

    public void Update()
    {
        DebugInputs();
    }

    public void FindPartyData()
    {
        PlayerParty = FindObjectOfType<PartyData>();
    }

    private void DebugInputs()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            var debugMon = GetComponent<MonsterData>();
            debugMon.CurrentStats = debugMon.CalculateStats(debugMon.Species, debugMon.Level);
            debugMon.CurrentHP = debugMon.CurrentStats.HP;
            debugMon.CurrentMP = debugMon.CurrentStats.MP;
            PlayerParty.PrimaryMonster = new MonsterData
            {
                Name = debugMon.Name,
                Level = debugMon.Level,
                Species = debugMon.Species,
                CurrentStats = debugMon.CurrentStats,
                CurrentHP = debugMon.CurrentHP,
                CurrentMP = debugMon.CurrentMP
            };
            PlayerParty.AddMonster(new MonsterData
            {
                Name = debugMon.Name,
                Level = debugMon.Level,
                Species = debugMon.Species,
                CurrentStats = debugMon.CurrentStats,
                CurrentHP = debugMon.CurrentHP,
                CurrentMP = debugMon.CurrentMP
            });
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


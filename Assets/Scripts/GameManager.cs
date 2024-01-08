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
        AddDebugMonsters();
    }

    private void AddDebugMonsters()
    {
        var debugMon = GetComponent<MonsterData>();
        debugMon.CurrentStats = debugMon.CalculateStats(debugMon.Species, debugMon.Level);
        debugMon.CurrentHP = debugMon.CurrentStats.HP;
        debugMon.CurrentMP = debugMon.CurrentStats.MP;
        PlayerParty.PrimaryMonster = debugMon;
        PlayerParty.AddMonster(debugMon);
    }

    public void FindPartyData()
    {
        PlayerParty = FindObjectOfType<PartyData>();
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


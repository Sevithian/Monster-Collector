using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public MonsterData EncounteredMonster { get; private set; }

    void Awake()
    {
        EncounteredMonster = GetComponent<MonsterData>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StoreEncounteredMonster(MonsterSpecies species, int level)
    {
        EncounteredMonster.Species = species;
        EncounteredMonster.Level = level;
        EncounteredMonster.CurrentStats = EncounteredMonster.CalculateStats(species, level);
        EncounteredMonster.Name = species.Name;
        EncounteredMonster.CurrentHP = EncounteredMonster.CurrentStats.HP;
        EncounteredMonster.CurrentMP = EncounteredMonster.CurrentStats.MP;
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Single);
    }
}


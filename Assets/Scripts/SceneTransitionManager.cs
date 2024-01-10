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
        EncounteredMonster = new MonsterData(species.ID);
        EncounteredMonster.Name = species.Name;
        EncounteredMonster.Species = species;
        EncounteredMonster.Level = level;
        EncounteredMonster.CurrentStats = EncounteredMonster.CalculateStats(species, level);
        EncounteredMonster.CurrentHP = EncounteredMonster.CurrentStats.HP;
        EncounteredMonster.CurrentMP = EncounteredMonster.CurrentStats.MP;
    }

    public void LoadBattleScene()
    {
        GameManager.Instance.SaveWorldState();
        WorldManager.Instance.ClearLevel();
        WorldManager.Instance.SpawnBattleground(GameManager.Instance.SavedWorldData.WorldID);
        SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Single);
    }
}


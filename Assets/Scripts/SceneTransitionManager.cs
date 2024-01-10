using System;
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
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        foreach (Transform child in this.transform)
            DontDestroyOnLoad(child.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneTransition(0);
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
        LoadSceneWithTransition(1);
    }

    public void LoadOverworldScene()
    {
        
        LoadSceneWithTransition(0);
    }

    public void LoadSceneWithTransition(int sceneType) //0 - Overworld, 1 - Battle
    {
        SceneTransition(1); // Play "wipe out" animation
        StartCoroutine(WaitForAnimationAndLoadScene(sceneType));
    }

    private IEnumerator WaitForAnimationAndLoadScene(int sceneType)
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(1); // Wait for the duration of the animation

        Time.timeScale = 1;

        switch (sceneType)
        {
            case 1:
                GameManager.Instance.SaveWorldState();
                WorldManager.Instance.ClearLevel();
                WorldManager.Instance.SpawnBattleground(GameManager.Instance.SavedWorldData.WorldID);
                SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Single);
                break;

            case 0:
                WorldManager.Instance.ClearLevel();
                WorldManager.Instance.SpawnBattleground(GameManager.Instance.SavedWorldData.WorldID);
                SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Single);
                break;
        }
    }

    public void SceneTransition(int animationID)
    {
        if(this.gameObject != null)
        {
            switch(animationID)
            {
                case 0:
                    GetComponentInChildren<Animator>().Play("FadeTransitionWipeIN");
                    return;
            
                case 1:
                    GetComponentInChildren<Animator>().Play("FadeTransitionWipeOut");
                    return;
            }
        }
    }
}


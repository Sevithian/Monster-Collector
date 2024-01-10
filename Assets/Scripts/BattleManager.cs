using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BattleManager : MonoBehaviour
{
    public TextMeshProUGUI EnemyName;
    public TextMeshProUGUI PlayerName;
    public Image EnemyHP;
    public Image PlayerHP;
    public Image EnemyMP;
    public Image PlayerMP;
    public GameObject EnemyObj;
    public GameObject PlayerObj;
    private MonsterData EnemyData;
    private MonsterData PlayerData;

    private void Start()
    {
        GrabEncounterData();

        PlayerData = GameManager.Instance.PlayerParty.PrimaryMonster;

        Instantiate(EnemyData.Species.SpritePrefab, EnemyObj.transform);
        Instantiate(PlayerData.Species.SpritePrefab, PlayerObj.transform);

        UpdateValues();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EndBattle();
    }

    private void EndBattle()
    {
        SceneTransitionManager.Instance.LoadOverworldScene();
    }

    private void GrabEncounterData()
    {
        EnemyData = new MonsterData(SceneTransitionManager.Instance.EncounteredMonster.SpeciesID);
        EnemyData.CopyData(SceneTransitionManager.Instance.EncounteredMonster);
        Debug.Log(EnemyData.Name);
    }

    public void UpdateValues()
    {
        EnemyName.text = EnemyData.Name;
        EnemyHP.fillAmount = (float)EnemyData.CurrentHP / EnemyData.CurrentStats.HP;
        EnemyMP.fillAmount = (float)EnemyData.CurrentMP / EnemyData.CurrentStats.MP;

        PlayerName.text = PlayerData.Name;
        PlayerHP.fillAmount = (float)PlayerData.CurrentHP / PlayerData.CurrentStats.HP;
        PlayerMP.fillAmount = (float)PlayerData.CurrentMP / PlayerData.CurrentStats.MP;
    }
}

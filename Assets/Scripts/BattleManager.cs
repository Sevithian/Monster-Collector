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
    public MonsterData EnemyData;
    public MonsterData PlayerData;

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

    internal void UseAttack(MonsterAttack attack, MonsterData target)
    {
        Debug.Log($"Using {attack.Name} on {target.Name}");
        //Check for accuracy
        if(attack.AccuracyRating > UnityEngine.Random.Range(0, 100))
        {
            //Apply Damage
            target.CurrentHP -= attack.BasePower;
        }
        else
        {
            Debug.Log("Missed");
        }

        UpdateValues();
    }

    public void EndBattle()
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

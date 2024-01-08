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
        EnemyData = EnemyObj.GetComponent<MonsterData>();
        GrabEncounterData();

        PlayerData = PlayerObj.GetComponent<MonsterData>();

        EnemyData.SpawnMonster();
        PlayerData.SpawnMonster();

        UpdateValues();
    }

    private void GrabEncounterData()
    {
        EnemyData.CopyData(SceneTransitionManager.Instance.EncounteredMonster);
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

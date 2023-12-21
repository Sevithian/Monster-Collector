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
    public MonsterData Enemy;
    public MonsterData Player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UpdateValues();
    }

    public void UpdateValues()
    {
        EnemyName.text = Enemy.Name;
        EnemyHP.fillAmount = (float)Enemy.CurrentHP / Enemy.CurrentStats.HP;
        EnemyMP.fillAmount = (float)Enemy.CurrentMP / Enemy.CurrentStats.MP;

        PlayerName.text = Player.Name;
        PlayerHP.fillAmount = (float)Player.CurrentHP / Player.CurrentStats.HP;
        PlayerMP.fillAmount = (float)Player.CurrentMP / Player.CurrentStats.MP;
    }
}

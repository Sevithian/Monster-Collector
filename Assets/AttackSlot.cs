using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackSlot : MonoBehaviour
{
    public MonsterAttack Attack;

    public void UseAttack()
    {
        FindObjectOfType<BattleManager>().UseAttack(Attack, FindObjectOfType<BattleManager>().EnemyData);
    }
}

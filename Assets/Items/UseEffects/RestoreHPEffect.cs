using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/RestoreHP")]
public class RestoreHPEffect : ItemEffect
{
    public override void Execute(MonsterData target)
    {
        target.RestoreHP(RestoreAmount);
    }
}
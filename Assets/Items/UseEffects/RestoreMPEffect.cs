using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffects/RestoreMP")]
public class RestoreMPEffect : ItemEffect
{
    public override void Execute(MonsterData target)
    {
        target.RestoreMP(RestoreAmount);
    }
}
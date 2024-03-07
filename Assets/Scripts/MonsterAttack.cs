using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { Physical, Spell }
public enum TargetType { Forced, Choose }
[CreateAssetMenu(fileName = "New Attack", menuName = "New Attack", order = 0)]
public class MonsterAttack : ScriptableObject
{
    public string Name;
    public int BasePower = 10;
    public AttackType Type;
    public TargetType Target;
    public int AccuracyRating = 95;
    public AttackEffect Effect;
    public string Description;
    public int MPCost;
}

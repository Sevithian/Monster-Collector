using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType { Demon, Plant, Beast, Material }
public enum MonsterRank { D, C, B, A }
public enum MonsterBehavior { Follow, Flee, None }

[CreateAssetMenu(fileName = "Monster", menuName = "New Monster",order = 0)]
public class MonsterSpecies : ScriptableObject
{
    public int ID;
    public string Name;
    public MonsterType Type;
    public MonsterRank Rank;
    public MonsterBehavior Behavior;
    public GameObject SpritePrefab;
    public MonsterStats BaseStats;
    public MonsterStats MaxStats;
    public MonsterAttack[] DefaultAttacks;
    public bool PlayerSeen = false;
    public bool PlayerCaught = false;
}

[System.Serializable]
public class MonsterStats
{
    public int HP;
    public int MP;
    public int ATK;
    public int DEF;
    public int AGI;
    public int INT;
}

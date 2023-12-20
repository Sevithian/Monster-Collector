using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType { Demon, Plant, Beast}
public enum MonsterRank { F, E, D, C, B, A, S }
public enum MonsterBehavior { Follow, Flee, None }
[CreateAssetMenu(fileName = "Monster", menuName = "New Monster",order = 0)]
public class MonsterSpecies : ScriptableObject
{
    public string Name;
    public MonsterType Type;
    public MonsterRank Rank;
    public MonsterBehavior Behavior;
    public GameObject SpritePrefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterOwner { Player, Enemy }
public class MonsterData : MonoBehaviour
{
    public string Name;
    public int Level;
    public MonsterSpecies Species;
    public int CurrentHP;
    public int CurrentMP;
    public MonsterStats CurrentStats;
    public MonsterOwner Type;

    public void SpawnMonster()
    {
        Instantiate(Species.SpritePrefab, this.transform);
        if(Type == MonsterOwner.Enemy)
        {
            Name = Species.Name;
            CurrentStats = CalculateStats(Species, Level);
            CurrentHP = CurrentStats.HP;
            CurrentMP = CurrentStats.MP;
        }
    }
    private MonsterStats CalculateStats(MonsterSpecies species, int level)
    {
        MonsterStats newStats = new MonsterStats();
        int offset = 1; // Offset to avoid log(0)
        double logFactor = Mathf.Pow(Mathf.Log(level + offset) / Mathf.Log(100 + offset), 4);
        newStats.HP = (int)(species.BaseStats.HP + logFactor * (species.MaxStats.HP - species.BaseStats.HP));
        newStats.MP = (int)(species.BaseStats.MP + logFactor * (species.MaxStats.MP - species.BaseStats.MP));
        newStats.ATK = (int)(species.BaseStats.ATK + logFactor * (species.MaxStats.ATK - species.BaseStats.ATK));
        newStats.DEF = (int)(species.BaseStats.DEF + logFactor * (species.MaxStats.DEF - species.BaseStats.DEF));
        newStats.AGI = (int)(species.BaseStats.AGI + logFactor * (species.MaxStats.AGI - species.BaseStats.AGI));
        newStats.INT = (int)(species.BaseStats.INT + logFactor * (species.MaxStats.INT - species.BaseStats.INT));
        return newStats;
    }

    public void Start()
    {
         SpawnMonster();
    }
}

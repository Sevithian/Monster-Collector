using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterOwner { Player, Enemy }

[System.Serializable]
public class MonsterData : MonoBehaviour
{
    public string Name;
    public int Level;
    public MonsterSpecies Species;
    public int CurrentHP;
    public int CurrentMP;
    public MonsterStats CurrentStats;
    public MonsterOwner Type;

    public MonsterStats CalculateStats(MonsterSpecies species, int level)
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

    public void CopyData(MonsterData source)
    {
        Species = source.Species;
        Level = source.Level;
        CurrentStats = source.CurrentStats;
        CurrentHP = source.CurrentHP;
        CurrentMP = source.CurrentMP;
        Name = source.Name;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyData : MonoBehaviour
{
    public MonsterData PrimaryMonster;
    public List<MonsterData> StorageMonsters;

    public void SwapMonsters(MonsterData monster1, MonsterData monster2)
    {
        if (monster1 == null || monster2 == null) return;

        if (monster1 == PrimaryMonster)
        {
            SwapWithPrimary(monster2);
        }
        else if (monster2 == PrimaryMonster)
        {
            SwapWithPrimary(monster1);
        }
        else
        {
            int index1 = StorageMonsters.IndexOf(monster1);
            int index2 = StorageMonsters.IndexOf(monster2);

            if (index1 != -1 && index2 != -1)
            {
                MonsterData temp = StorageMonsters[index1];
                StorageMonsters[index1] = StorageMonsters[index2];
                StorageMonsters[index2] = temp;
            }
        }
    }

    private void SwapWithPrimary(MonsterData monster)
    {
        if (!StorageMonsters.Contains(monster)) return;

        StorageMonsters[StorageMonsters.IndexOf(monster)] = PrimaryMonster;
        PrimaryMonster = monster;
    }

    public void AddMonster(MonsterData monster)
    {
        StorageMonsters.Add(monster);
    }
}

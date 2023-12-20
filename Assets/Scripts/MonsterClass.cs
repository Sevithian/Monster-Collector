using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClass : MonoBehaviour
{
    public MonsterSpecies Species;

    public void SpawnMonster()
    {
        Instantiate(Species.SpritePrefab, this.transform);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnMonster();
    }
}

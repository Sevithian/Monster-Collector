using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject OverworldMonster;
    public List<MonsterSpecies> LevelEnemies = new List<MonsterSpecies>();
    public int MinMonsterLevel = 10;
    public int MaxMonsterLevel = 15;

    private void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        var spawnLocations = FindObjectsOfType<MonsterSpawner>();
        foreach (var spawnLocation in spawnLocations)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(spawnLocation.transform.position, out hit, 2f, 1);
            var spawnedMon = Instantiate(OverworldMonster, hit.position, Quaternion.identity);
            spawnedMon.GetComponent<OverworldMonster>().Species = LevelEnemies[UnityEngine.Random.Range(0, LevelEnemies.Count)];
            spawnedMon.GetComponent<OverworldMonster>().Level = UnityEngine.Random.Range(MinMonsterLevel, MaxMonsterLevel + 1);
            spawnedMon.GetComponent<OverworldMonster>().Initialize();
        }
    }
}

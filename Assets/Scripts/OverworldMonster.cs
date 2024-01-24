using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OverworldMonster : MonoBehaviour
{
    public MonsterSpecies Species;
    public int Level;
    public float WanderRadius = 5f;
    public float FleeRadius = 5f;
    public float FollowRadius = 5f;
    public float MinWanderTime;
    public float MaxWanderTime;
    public float MinIdleTime;
    public float MaxIdleTime;
    public bool IsIdle;
    
    private NavMeshAgent NMA;
    private Vector3 Destination;
    private float WanderTime;
    private float IdleTime;
    private float Timer;

    private void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        IsIdle = true;
        IdleTime = UnityEngine.Random.Range(MinIdleTime, MaxIdleTime);
        WanderTime = UnityEngine.Random.Range(MinWanderTime, MaxWanderTime);
    }

    public void Update()
    {
        AnimateMonster();
        MoveAround();
        Timer += Time.deltaTime;
    }

    public void Initialize()
    {
        Instantiate(Species.SpritePrefab, this.transform);
    }

    private void AnimateMonster()
    {
        if (IsIdle)
            GetComponentInChildren<Animator>().Play("Idle");

        if (!IsIdle)
                GetComponentInChildren<Animator>().Play("Walk");
    }

    private void MoveAround()
    {
        if(!IsIdle && (Timer > WanderTime || Vector3.Distance(transform.position, Destination) < 0.5f))
        {
            Timer = 0;
            IsIdle = true;
            NMA.SetDestination(transform.position);
            IdleTime = UnityEngine.Random.Range(MinIdleTime, MaxIdleTime);
        }

        if(IsIdle && Timer > IdleTime)
        {
            Timer = 0;
            IsIdle = false;
            WanderTime = UnityEngine.Random.Range(MinWanderTime, MaxWanderTime);
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * WanderRadius;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, 1);
            Destination = hit.position;
            NMA.SetDestination(Destination);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerEncounter();
    }

    private void PlayerEncounter()
    {
        GameManager.Instance.FindPartyData();
        SceneTransitionManager.Instance.StoreEncounteredMonster(Species, Level);
        SceneTransitionManager.Instance.LoadBattleScene();
    }
}

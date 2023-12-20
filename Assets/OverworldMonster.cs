using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OverworldMonster : MonoBehaviour
{
    public MonsterSpecies Species;
    public MonsterClass Data;
    public NavMeshAgent NMA;
    public float WanderRadius = 5f;
    public float FleeRadius = 5f;
    public float FollowRadius = 5f;
    public Vector3 Destination;
    public float Timer;
    public float WanderTime;
    public float MinWanderTime;
    public float MaxWanderTime;
    public float IdleTime;
    public float MinIdleTime;
    public float MaxIdleTime;
    public bool IsIdle;

    private void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        AnimateMonster();
        MoveAround();
        Timer += Time.deltaTime;
    }

    private void AnimateMonster()
    {
        if (GetComponentInChildren<Animator>() != null && IsIdle)
            GetComponentInChildren<Animator>().Play("Idle");

        if (GetComponentInChildren<Animator>() != null && !IsIdle)
            GetComponentInChildren<Animator>().Play("Walk");
    }

    private void MoveAround()
    {
        if(!IsIdle && (Timer > MaxWanderTime || Vector3.Distance(transform.position, Destination) < 0.5f))
        {
            Timer = 0;
            IsIdle = true;
            IdleTime = UnityEngine.Random.Range(MinIdleTime, MaxIdleTime);
        }

        if(IsIdle && Timer > MaxIdleTime)
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
}

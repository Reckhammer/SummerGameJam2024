using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health;
    private NavMeshAgent agent;
    private Transform playerRef;

    private void Awake()
    {
        if (health == null)
            health = GetComponent<EnemyHealth>();
        
        agent = GetComponent<NavMeshAgent>();
        playerRef = GameObject.FindAnyObjectByType<PlayerMove>().transform;
    }

    private void Start()
    {
        health.Death += Died;
    }

    private void Update()
    {
        agent.SetDestination(playerRef.position);
    }

    private void Died()
    {

    }

    private IEnumerator DeathSequence()
    {
        yield return null;
    }
}

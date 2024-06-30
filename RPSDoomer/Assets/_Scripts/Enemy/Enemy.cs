using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemyHealth health;
    public int damage;
    public DamageType[] damageType;
    public float attackRate;
    protected float nextTimeToAttack = 0f;
    protected NavMeshAgent agent;
    protected Transform playerRef;

    public float despawnTime = 3f;

    private void Awake()
    {
        InitComponents();
    }

    protected virtual void Start()
    {
        InitEventListeners();

        StartCoroutine(ActiveSequence());
        StartCoroutine(RestartNavAgent());
        nextTimeToAttack = -1;
    }

    protected virtual void InitComponents()
    {
        if (health == null)
            health = GetComponent<EnemyHealth>();

        agent = GetComponent<NavMeshAgent>();
        playerRef = GameObject.FindAnyObjectByType<PlayerMove>().transform;
    }

    protected virtual void InitEventListeners()
    {
        health.Death += Died;
    }

    IEnumerator RestartNavAgent()
    {
        yield return null;

        agent.enabled = false;

        yield return new WaitForSeconds(1f);

        agent.enabled = true;
    }

    protected virtual IEnumerator ActiveSequence()
    {
        yield return null;
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Died()
    {
        StartCoroutine(DeathSequence());
    }

    protected virtual IEnumerator DeathSequence()
    {
        yield return null;

        yield return new WaitForSeconds(despawnTime);

        Destroy(gameObject);
    }
}

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
    protected float nextTimeToAttack;
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

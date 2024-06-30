using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        health.Death += Died;
    }

    private void Died()
    {

    }

    private IEnumerator DeathSequence()
    {
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy_ScissorsGrunt : Enemy
{
    [Header("Scissors Enemy")]
    public float playerAggroRange = 5f;
    private AnimationController animController;

    protected override void InitComponents()
    {
        base.InitComponents();
        animController = GetComponent<AnimationController>();
    }

    protected override IEnumerator ActiveSequence()
    {
        while (!health.isDead)
        {
            float playerDistance = Vector3.Distance(transform.position, playerRef.position);
            if (playerDistance > playerAggroRange)
            {
                //Debug.Log("Player is out of Scissors' aggro range. Just chilling", this);
                agent.SetDestination(this.transform.position);
            }
            else
            {
                //Debug.Log("Player is in Scissors' aggro range. Get em", this);
                agent.SetDestination(playerRef.position);
            }

            yield return null;
        }
    }

    protected override void Attack()
    {
        animController.PlayAttackAnimation();
        nextTimeToAttack = Time.time + attackRate;
    }

    private void OnTriggerStay(Collider collision)
    {
        //Debug.Log("Scissors collided with something", this);
        // Check if you collided with Player
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (Time.time > nextTimeToAttack)
            {
                //Debug.Log("Scissors collided with a player. Attack!!!", this);
                // Enemy hit a player 
                if (collision.gameObject.TryGetComponent(out Health otherHealth))
                    otherHealth.DamageHealth(damage, damageType[0]);
                // Add knock back?
                Attack();
            }
        }
    }
}

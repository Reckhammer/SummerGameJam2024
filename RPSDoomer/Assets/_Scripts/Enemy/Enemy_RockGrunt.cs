using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy_RockGrunt : Enemy
{
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
            if (agent.enabled)
                agent.SetDestination(playerRef.position);

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
        //Debug.Log($"Rock collided with {collision.gameObject.name}", this);
        // Check if you collided with Player
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (Time.time > nextTimeToAttack)
            {
                //Debug.Log("Rock collided with a player. Attack!!!", this);
                // Enemy hit a player 
                if (collision.gameObject.TryGetComponent(out Health otherHealth))
                    otherHealth.DamageHealth(damage, damageType[0]);
                // Add knock back?
                Attack();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PaperGrunt : Enemy
{
    [Header("Paper Enemy")]
    public float maxAttackRange = 10f;
    public float retreatRange = 3f;
    private float originalSpeed;
    public Transform projectileFirePoint;
    public Projectile projectilePrefab;
    private AnimationController animController;

    protected override void InitComponents()
    {
        base.InitComponents();
        animController = GetComponent<AnimationController>();

        originalSpeed = agent.speed;
    }

    protected override IEnumerator ActiveSequence()
    {
        while (!health.isDead)
        {
            float playerDistance = Vector3.Distance(transform.position, playerRef.position);
            if (playerDistance > maxAttackRange)
            {
                //Debug.Log("Player is out of Paper's Attack range. Get Closer", this);
                agent.speed = originalSpeed;
                agent.SetDestination(playerRef.position);
            }
            else if (playerDistance < retreatRange)
            {
                //Debug.Log("Player is too close to Paper. Run Away", this);
                agent.speed = originalSpeed;
                Vector3 retreatDirection = transform.position - playerRef.position;
                Vector3 retreatPosition = transform.position + retreatDirection;
                agent.SetDestination(retreatPosition);
            }
            else
            {
                //Debug.Log("Attacking Player");
                agent.speed = 0f;
                Attack();
            }

            yield return null;
        }
    }

    protected override void Attack()
    {
        if (Time.time > nextTimeToAttack)
        {
            animController.PlayAttackAnimation();
            nextTimeToAttack = Time.time + attackRate;

            // Shoot projectile at Player
            Projectile projectile = Instantiate(projectilePrefab, projectileFirePoint);
            projectile.Shoot(projectileFirePoint.forward);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Health health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        // Setup attack listener
        health.HealthChanged += PlayDamagedAnimation;
        health.Death += PlayDeathAnimation;
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    private void PlayDamagedAnimation()
    {
        animator.SetTrigger("Damaged");
    }

    private void PlayDeathAnimation()
    {
        animator.SetBool("IsDead", true);
    }
}

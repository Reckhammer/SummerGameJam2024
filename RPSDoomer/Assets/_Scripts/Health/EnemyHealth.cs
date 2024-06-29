using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [Header("Enemy Health")]
    public int maxRockHealth = 0;
    public int currentRockHealth;
    public int maxPaperHealth = 0;
    public int currentPaperHealth;
    public int maxScissorsHealth = 0;
    public int currentScissorsHealth;

    public event Action RockHealthDepleted;
    public event Action RockMaxHealthChanged;
    public event Action PaperHealthDepleted;
    public event Action PaperMaxHealthChanged;
    public event Action ScissorsHealthDepleted;
    public event Action ScissorsMaxHealthChanged;

    protected override void InitHealth()
    {
        currentHealth = maxRockHealth + maxPaperHealth + maxScissorsHealth;
        currentRockHealth = maxRockHealth;
        currentPaperHealth = maxPaperHealth;
        currentScissorsHealth = maxScissorsHealth;
    }

    public override void DamageHealth(int damageAmt, DamageType damageType)
    {
        if (damageType == DamageType.Rock)
        {
            currentRockHealth -= damageAmt;

            if (currentRockHealth <= 0)
            {
                damageAmt += -1 * currentRockHealth;
                currentRockHealth = 0;
                RockHealthDepleted?.Invoke();
            }
        }
        else if (damageType == DamageType.Paper)
        {
            currentPaperHealth -= damageAmt;

            if (currentPaperHealth <= 0)
            {
                damageAmt += -1 * currentPaperHealth;
                currentPaperHealth = 0;
                PaperHealthDepleted?.Invoke();
            }
        }
        else if (damageType == DamageType.Scissors)
        {
            currentScissorsHealth -= damageAmt;

            if (currentScissorsHealth <= 0)
            {
                damageAmt += -1 * currentScissorsHealth;
                currentScissorsHealth = 0;
                ScissorsHealthDepleted?.Invoke();
            }
        }

        ChangeHealth(damageAmt);
    }

    public void ChangeRockMaxHealth(int newMax)
    {
        maxRockHealth = newMax;

        if (currentRockHealth > maxRockHealth)
            currentRockHealth = maxRockHealth;
        else if (currentRockHealth < maxRockHealth)
            currentRockHealth += maxRockHealth - currentRockHealth;

        RockMaxHealthChanged?.Invoke();
    }

    public void ChangePaperMaxHealth(int newMax)
    {
        maxPaperHealth = newMax;

        if (currentPaperHealth > maxPaperHealth)
            currentPaperHealth = maxPaperHealth;
        else if (currentPaperHealth < maxPaperHealth)
            currentPaperHealth += maxPaperHealth - currentPaperHealth;

        PaperMaxHealthChanged?.Invoke();
    }

    public void ChangeScissorsMaxHealth(int newMax)
    {
        maxScissorsHealth = newMax;

        if (currentScissorsHealth > maxScissorsHealth)
            currentScissorsHealth = maxScissorsHealth;
        else if (currentScissorsHealth < maxScissorsHealth)
            currentScissorsHealth += maxScissorsHealth - currentScissorsHealth;

        ScissorsMaxHealthChanged?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : PlayerAttack
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            StartAttack();
        }
    }

    protected override void InitTrigger()
    {
        attackRangeTrigger.size = new Vector3(2, verticalRange, forwardRange);
        attackRangeTrigger.center = new Vector3(0, 0, forwardRange * 0.5f);
    }

    public override void StartAttack()
    {
        Debug.Log("Melee Attack sequence engaged");

        if (PlayerTargetManager.instance.enemiesInPlayerAtkRange.Count == 0)
            return;

        // Damage Enemies in Range
        foreach (Enemy enemy in PlayerTargetManager.instance.enemiesInPlayerAtkRange)
        {
            // damage enemy
            Debug.Log($"{enemy.gameObject.name} has been hit", this);
        }

        // Reset Timer
        nextTimeToFire = Time.time + fireRate;
    }
}

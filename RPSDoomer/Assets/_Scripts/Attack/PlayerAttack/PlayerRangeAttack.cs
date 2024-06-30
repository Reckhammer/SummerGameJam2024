using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : PlayerAttack
{
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            StartAttack();
        }
    }

    protected override void InitTrigger()
    {
        attackRangeTrigger.size = new Vector3(1, verticalRange, forwardRange);
        attackRangeTrigger.center = new Vector3(0, 0, forwardRange * 0.5f);
    }

    public override void StartAttack()
    {
        Debug.Log("Ranged Attack sequence engaged");
        
        // Reset Timer
        nextTimeToFire = Time.time + fireRate;

        if (PlayerTargetManager.instance.enemiesInPlayerAtkRange.Count == 0)
            return;

        // Damage Enemies in Range
        foreach (Enemy enemy in PlayerTargetManager.instance.enemiesInPlayerAtkRange)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, forwardRange * 1.5f, targetRaycastHitLayer))
            {
                if (hit.transform == enemy.transform)
                {
                    // Damage enemy
                    Debug.Log($"{enemy.gameObject.name} has been hit", this);
                    enemy.health.DamageHealth(damage, damageType);
                }

            }
        }

    }
}

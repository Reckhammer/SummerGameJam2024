using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float forwardRange = 2f;
    public float verticalRange = 2f;
    public float fireRate = 2f;
    protected float nextTimeToFire;

    public LayerMask targetRaycastHitLayer;

    protected BoxCollider attackRangeTrigger;

    private void Awake()
    {
        attackRangeTrigger = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        InitTrigger();
    }

    protected virtual void InitTrigger()
    {
        
    }

    public virtual void StartAttack()
    {
        //Debug.Log("Attack sequence engaged");

        // Damage Enemies in Range
        foreach (Enemy enemy in PlayerTargetManager.instance.enemiesInPlayerAtkRange)
        {
            // damage enemy
            Debug.Log($"{enemy.gameObject.name} has been hit", this);
        }

        // Reset Timer
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy collidedEnemy))
        {
            PlayerTargetManager.instance.AddEnemy(collidedEnemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy collidedEnemy))
        {
            PlayerTargetManager.instance.RemoveEnemy(collidedEnemy);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Set Collider to Range")]
    public void SetColliderToRange()
    {
        attackRangeTrigger = GetComponent<BoxCollider>();
        InitTrigger();
    }
#endif
}

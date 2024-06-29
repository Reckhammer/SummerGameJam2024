using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float forwardRange = 2f;
    public float verticalRange = 2f;
    public float fireRate = 2f;
    private float nextTimeToFire;

    public LayerMask raycastHitLayer;

    private BoxCollider attackRangeTrigger;

    private void Awake()
    {
        attackRangeTrigger = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        InitTrigger();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Attack();
        }
    }

    private void InitTrigger()
    {
        attackRangeTrigger.size = new Vector3(2, verticalRange, forwardRange);
        attackRangeTrigger.center = new Vector3(0, 0, forwardRange * 0.5f);
    }

    private void Attack()
    {
        Debug.Log("Fire sequence engaged");

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
}

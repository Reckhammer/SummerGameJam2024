using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public float forwardRange = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
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
        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    private void InitTrigger()
    {
        attackRangeTrigger.size = new Vector3(1, verticalRange, forwardRange);
        attackRangeTrigger.center = new Vector3(0, 0, forwardRange * 0.5f);
    }

    private void Fire()
    {
        Debug.Log("Fire sequence engaged");

        // Damage Enemies in Range
        foreach (Enemy enemy in PlayerTargetManager.instance.enemiesInPlayerAtkRange)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, forwardRange * 1.5f, raycastHitLayer))
            {
                if (hit.transform == enemy.transform)
                {
                    // damage enemy
                    Debug.Log($"{enemy.gameObject.name} has been hit", this);
                }

            }
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

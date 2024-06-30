using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public DamageType damageType;
    public float forwardRange = 2f;
    public float verticalRange = 2f;
    public float fireRate = 2f;
    protected float nextTimeToFire;

    public GameObject hudElements;
    protected AnimationController animController;

    public LayerMask targetRaycastHitLayer;

    protected BoxCollider attackRangeTrigger;

    private void Awake()
    {
        attackRangeTrigger = GetComponent<BoxCollider>();

        if (hudElements != null)
            animController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        InitTrigger();
    }

    protected virtual void InitTrigger()
    {
        Debug.LogError("Init Trigger Function not implemented", this);
    }

    public virtual void StartAttack()
    {
        Debug.LogError("Start Attack Function not implemented", this);
    }

    public void ChangeAttackDamageType(DamageType newType)
    {
        damageType = newType;
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

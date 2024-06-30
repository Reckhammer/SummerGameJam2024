using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 5f;
    public float timeToDestroy = 3;
    private Vector3 travelDirection;
    private Coroutine travelCoroutine;

    public int damage = 1;
    public DamageType damageType = DamageType.None;
    public string[] validTargetLayers;

    public void Shoot(Vector3 direction)
    {
        travelDirection = direction;
        travelCoroutine = StartCoroutine(ProjectileTravelCoroutine());
    }

    private IEnumerator ProjectileTravelCoroutine()
    {
        StartCoroutine(DestroyAfterTimeCoroutine());

        while(true)
        {
            transform.position += travelDirection * projectileSpeed * Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator DestroyAfterTimeCoroutine()
    {
        yield return null;

        yield return new WaitForSeconds(timeToDestroy);

        StopCoroutine(travelCoroutine);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ProjectileIgnore"))
            return;

        //Debug.Log($"{other.gameObject.name} was hit", this);
        for (int ind  = 0; ind < validTargetLayers.Length; ind++)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(validTargetLayers[ind]))
            {
                if (other.TryGetComponent(out Health otherHealth))
                    otherHealth.DamageHealth(damage, damageType);

                break;
            }
        }

        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class TeleportOnTrigger : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} hit the trigger");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.gameObject.transform.position = teleportPoint.position;
    }
}

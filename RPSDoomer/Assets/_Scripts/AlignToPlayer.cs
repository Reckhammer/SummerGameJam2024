using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToPlayer : MonoBehaviour
{
    private Transform target;

    public bool canLookVertically = false;

    private void Awake()
    {
        target = GameObject.FindAnyObjectByType<PlayerMove>().transform;
    }

    private void Start()
    {
        StartCoroutine(AlignThisToPlayer());
    }

    private IEnumerator AlignThisToPlayer()
    {
        while(true)
        {
            if (canLookVertically)
            {
                transform.LookAt(target);
            }
            else
            {
                Vector3 modifiedTargetPos = target.position;
                modifiedTargetPos.y = transform.position.y;

                transform.LookAt(modifiedTargetPos);
            }
            
            yield return null;
        }

    }
}

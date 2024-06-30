using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;
    public bool canMove = true;

    private float xMousePos;
    private float smoothedMousePos;

    private float currentLookingPos;

    private void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GetComponent<Health>().Death += DisableMovement;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayerCamera();
    }

    private void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    private void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    private void MovePlayerCamera()
    {
        if (canMove)
        {
            currentLookingPos += smoothedMousePos;
            transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);

        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }
}

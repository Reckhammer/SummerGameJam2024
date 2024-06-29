using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float playerGravity = -10f;

    private CharacterController myController;
    private Vector3 inputVector;
    private Vector3 movementVector;

    public Animator camAnimator;
    private bool isWalking = false;

    private void Awake()
    {
        myController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();

        CheckForHeadBob();
        SetAnimations();
    }

    private void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Get player inputs
        inputVector.Normalize(); // Normalize the vector to prevent vectors being added during diagonal
        inputVector = transform.TransformDirection(inputVector); // Make the movement relative to the player

        movementVector = (inputVector * movementSpeed) + (Vector3.up * playerGravity);
    }

    private void MovePlayer()
    {
        myController.Move(movementVector * Time.deltaTime);
    }

    private void CheckForHeadBob()
    {
        if (myController.velocity.magnitude > 0.1f)
            isWalking = true;
        else
            isWalking = false;
    }

    private void SetAnimations()
    {
        camAnimator.SetBool("IsWalking", isWalking);
    }
}

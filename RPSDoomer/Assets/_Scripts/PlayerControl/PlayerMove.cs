using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float momentumDamping = 5f;
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

        SetAnimations();
    }

    private void GetInput()
    {
        if (IsMovementInputDown())
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Get player inputs
            inputVector.Normalize(); // Normalize the vector to prevent vectors being added during diagonal
            inputVector = transform.TransformDirection(inputVector); // Make the movement relative to the player

            isWalking = true;
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        movementVector = (inputVector * movementSpeed) + (Vector3.up * playerGravity);
    }

    private bool IsMovementInputDown()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
            return true;
        else
            return false;
    }

    private void MovePlayer()
    {
        myController.Move(movementVector * Time.deltaTime);
    }

    private void SetAnimations()
    {
        camAnimator.SetBool("IsWalking", isWalking);
    }
}

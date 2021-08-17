using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput input;
    [SerializeField] private Rigidbody rb;

    public float force = 15f;
    public float topSpeed = 5f;

    private Vector2 moveInputVector;

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInputVector = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        animator.SetFloat("hInput", moveInputVector.x);
        animator.SetFloat("vInput", moveInputVector.y);
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = Vector3.ClampMagnitude(new Vector3(moveInputVector.x, 0, moveInputVector.y),1);
        if (rb.velocity.magnitude < topSpeed)
        {
            rb.AddForce(moveVector * force);
        }
    }
}

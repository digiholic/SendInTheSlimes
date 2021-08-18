using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput input;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterSkinController skin;

    public float force = 15f;
    public float topSpeed = 5f;

    
    private Vector2 moveInputVector;
    private bool lockControls;

    private void Start()
    {
        skin.ChangeMaterialSettings(input.playerIndex);
        transform.position = GameObject.FindGameObjectWithTag($"Spawn{input.playerIndex}").transform.position;
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        if (lockControls) moveInputVector = Vector2.zero;
        else moveInputVector = context.ReadValue<Vector2>();
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

    public void HandleConfirm()
    {
        FindObjectOfType<GameManager>().EnemySpawner.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane"))
        {
            animator.SetBool("IsFalling", true);
            lockControls = true;
            skin.ChangeEyeOffset(CharacterSkinController.EyePosition.dead);
            transform.Rotate(-90f, 0f, 0f);
        }
    }
}

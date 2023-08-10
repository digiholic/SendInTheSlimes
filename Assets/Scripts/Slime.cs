using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public float speed;

    void FixedUpdate()
    {
        rb.AddForce(Vector3.left * speed, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane"))
        {
            Destroy(gameObject);
        }
    }
}
